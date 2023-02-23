using DataAccessLayer.Entities;
using Merchandise.Exceptions;
using Merchandise.Models;
using Merchandise.Services;
using Microsoft.AspNetCore.Mvc;

namespace Merchandise.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class MerchandiseController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private readonly OrderedProductService _orderedProductService;
        private readonly MapService _mapService;

        public MerchandiseController(
            OrderService orderService, 
            ProductService productService,
            OrderedProductService orderedProductService,
            MapService mapService)
        {
            _orderService = orderService;
            _productService = productService;
            _orderedProductService = orderedProductService;
            _mapService = mapService;
        }

        [HttpGet]
        [ActionName("catalogue")]
        public async Task<JsonResult> CatalogueAsync(int skip = 0, int take = 10)
            => new(await _productService.GetProductsAsync(skip, take));

        [HttpGet]
        [ActionName("cart")]
        public async Task<JsonResult> CartAsync(Guid orderId)
        {
            var order = await _orderService.FindOrderAsync(orderId);
            var orderedProducts = await _orderedProductService.GetOrderedProductsAsync(orderId);
            return new(_mapService.MapToOrderModel(order, orderedProducts));
        }

        [HttpPost]
        [ActionName("add-to-cart")]
        public async Task<JsonResult> AddToCartAsync(Guid productId, int productsNum = 1, Guid orderId = default)
        {
            if (productsNum < 1)
                throw new IncorrectProductsNumberException();

            var product = await _productService.FindProductAsync(productId);

            if (product.Number < productsNum)
                throw new NotEnoughInStockException();

            if (orderId == default)
                return new(await AddToNewOrderAsync(product, productsNum));

            return new(await AddToExistingOrderAsync(productId, productsNum, orderId));
        }

        [HttpPut]
        [ActionName("add-one")]
        public async Task<JsonResult> AddOneAsync(Guid productId, Guid orderId)
            => new((await ChangeNumberAsync(productId, 1, orderId)).OrderModel);

        [HttpPut]
        [ActionName("remove-one")]
        public async Task<JsonResult> RemoveOneAsync(Guid productId, Guid orderId)
        {
            var (orderModel, order) = await ChangeNumberAsync(productId, -1, orderId);
            return await MakeJsonBasedOnDeletionAsync(orderModel, order);
        }

        [HttpPut]
        [ActionName("set-number")]
        public async Task<JsonResult> SetNumberAsync(Guid productId, int productsNumber, Guid orderId)
        {
            var (orderModel, order) = await ChangeNumberAsync(productId, productsNumber, orderId, true);
            return await MakeJsonBasedOnDeletionAsync(orderModel, order);
        }

        [HttpDelete]
        [ActionName("remove-from-cart")]
        public async Task<JsonResult> RemoveFromCartAsync(Guid productId, Guid orderId)
        {
            var (orderModel, order) = await ChangeNumberAsync(productId, 0, orderId, true);
            return await MakeJsonBasedOnDeletionAsync(orderModel, order);
        }

        [HttpDelete]
        [ActionName("clean-cart")]
        public async Task<JsonResult> CleanCartAsync(Guid orderId)
        {
            var order = await _orderService.FindOrderAsync(orderId);
            await _orderService.DeleteOrderAsync(order);
            return new(_mapService.MapToOrderDeletionModel(order));
        }

        private async Task<OrderModel> AddToNewOrderAsync(Product product, int productsNum)
        {
            var order = await _orderService.CreateOrderAsync();
            await _orderedProductService.OrderProductAsync(product.Id, productsNum, order.Id);
            
            return _mapService.MapToOrderModel(order, new() {
                _mapService.MapToOrderedProductModel(product, productsNum) 
            });
        }

        private async Task<OrderModel> AddToExistingOrderAsync(Guid productId, int productsNum, Guid orderId)
        {
            var foundOrder = await _orderService.FindOrderAsync(orderId);
            var orderedProduct = await _orderedProductService.FindDeletedOrderedProductAsync(productId, orderId);

            if (orderedProduct == null)
                await _orderedProductService.OrderProductAsync(productId, productsNum, orderId);
            else
                await _orderedProductService.ChangeOrderedProduct(orderedProduct, productsNum, DateTimeOffset.UtcNow);

            var orderedProducts = await _orderedProductService.GetOrderedProductsAsync(orderId);
            return _mapService.MapToOrderModel(foundOrder, orderedProducts);
        }

        private async Task<(OrderModel OrderModel, Order Order)> ChangeNumberAsync(
            Guid productId, 
            int productsNumber, 
            Guid orderId,
            bool setDirectly = false)
        {
            var orderedProduct = await _orderedProductService.FindActualOrderedProductAsync(productId, orderId);
            var newNumber = setDirectly ? productsNumber : orderedProduct.Number + productsNumber;

            if (newNumber < 0)
                throw new IncorrectProductsNumberException();

            var product = await _productService.FindProductAsync(productId);

            if (newNumber > product.Number)
                throw new NotEnoughInStockException();

            // Не используем GetOrderWithProductsAsync, потому что надо пока просто проверить, существет ли заказ
            var order = await _orderService.FindOrderAsync(orderId);
            await _orderedProductService.ChangeOrderedProduct(orderedProduct, newNumber);
            var orderedProducts = await _orderedProductService.GetOrderedProductsAsync(orderId);
            return (_mapService.MapToOrderModel(order, orderedProducts), order);
        }

        private async Task<OrderDeletionModel?> DeleteOrderIfEmptyAsync(OrderModel orderModel, Order order)
        {
            if (orderModel.Products.Count > 0)
                return null;

            await _orderService.DeleteOrderAsync(order);
            return _mapService.MapToOrderDeletionModel(order);
        }

        private async Task<JsonResult> MakeJsonBasedOnDeletionAsync(OrderModel orderModel, Order order)
        {
            var maybeDeletedOrder = await DeleteOrderIfEmptyAsync(orderModel, order);
            return new(maybeDeletedOrder != null ? maybeDeletedOrder : orderModel); // ?? не работает?
        }
    }
}

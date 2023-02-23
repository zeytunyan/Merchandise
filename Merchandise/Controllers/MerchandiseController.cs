using DataAccessLayer;
using DataAccessLayer.Entities;
using Merchandise.Exceptions;
using Merchandise.Models;
using Merchandise.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Merchandise.Controllers
{
    [Route("api/[action]")]
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
        public async Task<JsonResult> Catalogue(int skip = 0, int take = 10)
            => new(await _productService.GetProductsAsync(skip, take));

        [HttpGet]
        public async Task<JsonResult> Cart(Guid orderId)
        {
            var order = await _orderService.FindOrderAsync(orderId);
            var orderedProducts = await _orderedProductService.GetOrderedProductsAsync(orderId);
            return new(_mapService.MapToOrderModel(order, orderedProducts));
        }

        [HttpPost]
        public async Task<JsonResult> AddToCart(Guid productId, int productsNum = 1, Guid orderId = default)
        {
            if (productsNum < 1)
                throw new IncorrectProductsNumberException();

            var product = await _productService.FindProductAsync(productId);

            if (product.Number < productsNum)
                throw new NotEnoughInStockException();

            if (orderId == default)
                return new(await AddToNewOrder(product, productsNum));

            return new(await AddToExistingOrder(productId, productsNum, orderId));
        }

        [HttpPut]
        public async Task<JsonResult> AddOne(Guid productId, Guid orderId)
            => new((await ChangeNumber(productId, 1, orderId)).OrderModel);

        [HttpPut]
        public async Task<JsonResult> RemoveOne(Guid productId, Guid orderId)
        {
            var (orderModel, order) = await ChangeNumber(productId, -1, orderId);
            return await MakeJsonBasedOnDeletion(orderModel, order);
        }

        [HttpPut]
        public async Task<JsonResult> SetNumber(Guid productId, int productsNumber, Guid orderId)
        {
            var (orderModel, order) = await ChangeNumber(productId, productsNumber, orderId, true);
            return await MakeJsonBasedOnDeletion(orderModel, order);
        }

        [HttpDelete]
        public async Task<JsonResult> RemoveFromCart(Guid productId, Guid orderId)
        {
            var (orderModel, order) = await ChangeNumber(productId, 0, orderId, true);
            return await MakeJsonBasedOnDeletion(orderModel, order);
        }

        [HttpDelete]
        public async Task<JsonResult> CleanCart(Guid orderId)
        {
            var order = await _orderService.FindOrderAsync(orderId);
            await _orderService.DeleteOrderAsync(order);
            return new(_mapService.MapToOrderDeletionModel(order));
        }

        private async Task<OrderModel> AddToNewOrder(Product product, int productsNum)
        {
            var order = await _orderService.CreateOrderAsync();
            await _orderedProductService.OrderProductAsync(product.Id, productsNum, order.Id);
            
            return _mapService.MapToOrderModel(order, new() {
                _mapService.MapToOrderedProductModel(product, productsNum) 
            });
        }

        private async Task<OrderModel> AddToExistingOrder(Guid productId, int productsNum, Guid orderId)
        {
            var foundOrder = await _orderService.FindOrderAsync(orderId);
            var orderedProduct = await _orderedProductService.FindDeletedOrderedProductAsync(productId, orderId);

            if (orderedProduct == null)
                await _orderedProductService.OrderProductAsync(productId, productsNum, orderId);
            else
                await _orderedProductService.ChangeOrderedProductsNumberAsync(orderedProduct, productsNum);

            var orderedProducts = await _orderedProductService.GetOrderedProductsAsync(orderId);
            return _mapService.MapToOrderModel(foundOrder, orderedProducts);
        }

        private async Task<(OrderModel OrderModel, Order Order)> ChangeNumber(
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
            await _orderedProductService.ChangeOrderedProductsNumberAsync(orderedProduct, newNumber);
            var orderedProducts = await _orderedProductService.GetOrderedProductsAsync(orderId);
            return (_mapService.MapToOrderModel(order, orderedProducts), order);
        }

        private async Task<OrderDeletionModel?> DeleteOrderIfEmpty(OrderModel orderModel, Order order)
        {
            if (orderModel.Products.Count < 1)
                return null;

            await _orderService.DeleteOrderAsync(order);
            return _mapService.MapToOrderDeletionModel(order);
        }

        private async Task<JsonResult> MakeJsonBasedOnDeletion(OrderModel orderModel, Order order)
        {
            var maybeDeletedOrder = await DeleteOrderIfEmpty(orderModel, order);
            return new(maybeDeletedOrder != null ? maybeDeletedOrder : orderModel); // ?? не работает?
        }
    }
}

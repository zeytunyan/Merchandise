using DataAccessLayer.Entities;
using DataAccessLayer;
using Merchandise.Exceptions;
using Microsoft.EntityFrameworkCore;
using Merchandise.Models;

namespace Merchandise.Services
{
    public class OrderedProductService
    {
        private readonly DataContext _dataContext;
        private readonly MapService _mapService;

        public OrderedProductService(DataContext dataContext, MapService mapService)
        {
            _dataContext = dataContext;
            _mapService= mapService;
        }

        public async Task<List<OrderedProductModel>> GetOrderedProductsAsync(Guid orderId)
        {
            return await _dataContext.OrderedProducts
                .Include(op => op.Product)
                .Where(op => op.OrderId == orderId && op.Number > 0 && op.Product != null)
                .OrderBy(op => op.AddDate)
                .Select(op => _mapService.MapToOrderedProductModel(op.Product!, op.Number))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task OrderProductAsync(Guid productId, int productsNum, Guid orderId)
        {
            var orderedProduct = new OrderedProduct
            {
                ProductId = productId,
                OrderId = orderId,
                Number = productsNum
            };

            await _dataContext.OrderedProducts.AddAsync(orderedProduct);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ChangeOrderedProduct(
            OrderedProduct orderedProduct,
            int newNumber,
            DateTimeOffset newAddDate = default)
        {
            orderedProduct.Number = newNumber;

            if (newAddDate != default)
                orderedProduct.AddDate = newAddDate;

            await _dataContext.SaveChangesAsync();
        }

        public async Task<OrderedProduct> FindActualOrderedProductAsync(Guid productId, Guid orderId)
        {
            var orderedProduct = await FindOrderedProductAsync(productId, orderId);

            if (orderedProduct == null || orderedProduct.Number < 1)
                throw new OrderedProductNotFoundException();

            return orderedProduct;
        }

        public async Task<OrderedProduct?> FindDeletedOrderedProductAsync(Guid productId, Guid orderId)
        {
            var orderedProduct = await FindOrderedProductAsync(productId, orderId);

            if (orderedProduct != null && orderedProduct.Number > 0)
                throw new ProductPresentInOrderException();

            return orderedProduct;
        }

        public async Task<OrderedProduct?> FindOrderedProductAsync(Guid productId, Guid orderId)
        {
            return await _dataContext.OrderedProducts
                .FirstOrDefaultAsync(op => op.ProductId == productId && op.OrderId == orderId);
        }
    }
}

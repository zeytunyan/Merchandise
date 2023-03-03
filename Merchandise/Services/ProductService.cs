using DataAccessLayer;
using DataAccessLayer.Entities;
using Merchandise.Exceptions;
using Merchandise.Models;
using Microsoft.EntityFrameworkCore;

namespace Merchandise.Services
{
    public class ProductService
    {

        private readonly DataContext _dataContext;
        private readonly MapService _mapService;

        public ProductService(DataContext dataContext, MapService mapService)
        {
            _dataContext = dataContext;
            _mapService = mapService;
        }

        public async Task<List<ProductModel>> GetProductsAsync(int skip, int take)
        {
            return await _dataContext.Products
             .OrderBy(p => p.Name)
             .Skip(skip).Take(take)
             .Select(p => _mapService.MapToProductModel(p))
             .AsNoTracking()
             .ToListAsync();
        }

        public async Task<Product> FindProductAsync(Guid productId)
        {
            // Если продукта нет на складе, он все равно выдается
            var product = await _dataContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product ?? throw new ProductNotFoundException();
        }

        public async Task AddProductAsync(Product product)
        {
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Product> RemoveProductAsync(Guid productId)
        {
            var product = await FindProductAsync(productId);

            if (product.Number == 0)
                throw new NotOnSaleException();

            product.Number = 0;
            await _dataContext.SaveChangesAsync();
            return product;
        }
    }
}

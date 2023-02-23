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
            var product = await _dataContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product ?? throw new ProductNotFoundException();
        }
    }
}

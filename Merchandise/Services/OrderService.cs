using DataAccessLayer;
using DataAccessLayer.Entities;
using Merchandise.Exceptions;
using Merchandise.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Merchandise.Services
{
    public class OrderService
    {
        private readonly DataContext _dataContext;
        private readonly MapService _mapService;
        
        public OrderService(DataContext dataContext, MapService mapService)
        {
            _dataContext = dataContext;
            _mapService = mapService;
        }

        public async Task<List<ShortOrderModel>> GetOrdersAsync()
        {
            return await _dataContext.Orders
                .Where(o => !o.IsDeleted)
                .Select(o => _mapService.MapToShortOrderModel(o))
                .ToListAsync();
        }

        public async Task<Order> CreateOrderAsync()
        {
            var addedOrder = await _dataContext.Orders.AddAsync(new());
            await _dataContext.SaveChangesAsync();
            return addedOrder.Entity;
        }

        public async Task DeleteOrderAsync(Order order)
        {
            order.IsDeleted = true;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Order> FindOrderAsync(Guid orderId)
        {
            var order = await _dataContext.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted);

            return order ?? throw new OrderNotFoundException();
        }
    }
}

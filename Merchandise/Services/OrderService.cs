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
        
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
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

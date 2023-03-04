using Merchandise.Services;
using Microsoft.AspNetCore.Mvc;

namespace Merchandise.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ActionName("Orders")]
        public async Task<JsonResult> OrdersAsync(int skip = 0, int take = 20) 
            => new(await _orderService.GetOrdersAsync(skip, take));
    }
}

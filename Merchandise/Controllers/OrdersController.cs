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
        public async Task<JsonResult> OrdersAsync() 
            => new(await _orderService.GetOrdersAsync());
    }
}

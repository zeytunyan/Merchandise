using Merchandise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchandise.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private readonly OrderedProductService _orderedProductService;
        private readonly MapService _mapService;

        public OrdersController(
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
        [ActionName("Orders")]
        public async Task<JsonResult> OrdersAsync() 
            => new(await _orderService.GetOrdersAsync());
    }
}

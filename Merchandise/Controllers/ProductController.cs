﻿using Merchandise.Models;
using Merchandise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchandise.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private readonly OrderedProductService _orderedProductService;
        private readonly MapService _mapService;

        public ProductController(
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
        [ActionName("Catalogue")]
        public async Task<JsonResult> CatalogueAsync(int skip = 0, int take = 10)
            => new(await _productService.GetProductsAsync(skip, take));

        [HttpPost]
        [ActionName("Add")]
        public async Task<JsonResult> AddProductAsync([FromForm] ProductCreationModel productCreation)
        {
            var product = _mapService.MapToProduct(productCreation);
            await _productService.AddProductAsync(product);
            return new(_mapService.MapToProductModel(product));
        }

        [HttpDelete]
        [ActionName("Remove")]
        public async Task<JsonResult> RemoveProductAsync(Guid id)
            => new(_mapService.MapToProductModel(await _productService.RemoveProductAsync(id)));


    }
}
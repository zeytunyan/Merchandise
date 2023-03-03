using DataAccessLayer.Entities;
using Merchandise.Models;
using System.Xml.Linq;

namespace Merchandise.Services
{
    public class MapService
    {
        public MapService() { }

        public ProductModel MapToProductModel(Product product) =>
            new(product.Id, product.Name, product.Price, product.Description, product.Number);

        public Product MapToProduct(ProductCreationModel productCreationModel) => new() 
        { 
                Name = productCreationModel.Name,
                Price = productCreationModel.Price,
                Number = productCreationModel.Number ?? 1,
                Description = productCreationModel.Description
        };

        public OrderedProductModel MapToOrderedProductModel(Product product, int orderedNumber) => 
            new(product.Id, product.Name, product.Price, product.Description, product.Number, orderedNumber);

        public OrderModel MapToOrderModel(Order order, List<OrderedProductModel> products) =>
            new(order.Id, order.Created, order.Confirmed, products.ToList());

        public ShortOrderModel MapToShortOrderModel(Order order) =>
            new(order.Id, order.Created, order.Confirmed);

        public OrderDeletionModel MapToOrderDeletionModel(Order order) 
            => new(order.Id, order.Created, order.IsDeleted);
    }
}

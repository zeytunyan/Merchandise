namespace Merchandise.Models
{
    public record OrderModel
    (
        Guid Id,
        DateTimeOffset Created,
        DateTimeOffset? Confirmed,
        List<OrderedProductModel> Products 
    ) : ShortOrderModel(Id, Created, Confirmed);
}

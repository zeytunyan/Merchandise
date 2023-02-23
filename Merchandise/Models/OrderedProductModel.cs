namespace Merchandise.Models
{
    public record OrderedProductModel
    (
        Guid Id,
        string Name,
        int Price,
        string? Description,
        int Number,
        int OrderedNumber
    ) 
    : ProductModel(Id, Name, Price, Description, Number);
}

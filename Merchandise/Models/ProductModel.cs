namespace Merchandise.Models
{
    public record ProductModel
    (
        Guid Id,
        string Name,
        int Price, 
        string? Description, 
        int Number
    );
}

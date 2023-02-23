namespace Merchandise.Models
{
    public record OrderDeletionModel
    (
        Guid Id,
        DateTimeOffset Created,
        bool IsDeleted
    );
}

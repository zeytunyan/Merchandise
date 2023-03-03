namespace Merchandise.Models
{
    public record ShortOrderModel
    (
        Guid Id,
        DateTimeOffset Created,
        DateTimeOffset? Confirmed
    );
}

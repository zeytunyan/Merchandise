namespace DataAccessLayer.Entities
{
    public class OrderedProduct
    {
        public Guid OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public DateTimeOffset AddDate { get; set; } = DateTimeOffset.UtcNow;

        public int Number { get; set; } = 1;
    }
}

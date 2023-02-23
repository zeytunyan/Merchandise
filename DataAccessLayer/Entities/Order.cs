namespace DataAccessLayer.Entities
{
    public class Order
    { 
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? Confirmed { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<OrderedProduct>? ProductAdditions { get; set; }
    }
}

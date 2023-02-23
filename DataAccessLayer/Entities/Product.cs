namespace DataAccessLayer.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string? Description { get; set; }
        public int Number { get; set; }
        
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<OrderedProduct>? OrderedOnes { get; set; }
    }
}

using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderedProduct> OrderedProducts => Set<OrderedProduct>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(Products));
            modelBuilder.Entity<Order>().ToTable(nameof(Orders));

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(o => o.Products)
                .UsingEntity<OrderedProduct>(
                    op => op
                    .HasOne(po => po.Order)
                    .WithMany(o => o.ProductAdditions)
                    .HasForeignKey(po => po.OrderId),
                   
                    op => op
                    .HasOne(oo => oo.Product)
                    .WithMany(p => p.OrderedOnes)
                    .HasForeignKey(oo => oo.ProductId),
                    
                    op => 
                    {
                        op.HasKey(e => new { e.ProductId, e.OrderId });
                        op.ToTable(nameof(OrderedProducts));
                    });

            modelBuilder.Entity<Product>().HasData(
                new Product { Name = "Milk", Price = 100, Description = "Cow's milk", Number = 100 },
                new Product { Name = "Meat", Price = 300, Description = "Fresh meat", Number = 50 },
                new Product { Name = "Bananas", Price = 30, Description = "Ripe bananas", Number = 10 },
                new Product { Name = "Bread", Price = 40, Description = "A loaf of bread", Number = 20 },
                new Product { Name = "Water", Price = 20, Description = "Bottled water", Number = 30 },
                new Product { Name = "Cheese", Price = 400, Description = "Cheese with mold", Number = 40 },
                new Product { Name = "Sausages", Price = 100, Description = "", Number = 200 },
                new Product { Name = "Fish", Price = 300, Description = "Fresh fish", Number = 100 },
                new Product { Name = "Tomatoes", Price = 100, Description = "Red tomatoes", Number = 100 },
                new Product { Name = "Cookies", Price = 100, Description = "Tasty cookies", Number = 15 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(b => b.MigrationsAssembly("Merchandise")); 
    }
}

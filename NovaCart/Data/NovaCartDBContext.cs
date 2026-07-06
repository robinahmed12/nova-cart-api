using Microsoft.EntityFrameworkCore;
using NovaCart.Model;

namespace NovaCart.Data
{
    public class NovaCartDBContext : DbContext
    {
        public NovaCartDBContext(DbContextOptions<NovaCartDBContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defining the relationship between Order and OrderItems with Cascade Delete Behavior
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Electronics",
                    Description = "Electronic devices and gadgets"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Books",
                    Description = "Various genres of books and literature"
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Clothing",
                    Description = "Men's and women's apparel"
                }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Laptop",
                    Price = 1500m,
                    CategoryId = 1,
                    Description = "High performance laptop"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Smartphone",
                    Price = 800m,
                    CategoryId = 1,
                    Description = "Latest model smartphone"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "ASP.NET Core Book",
                    Price = 40m,
                    CategoryId = 2,
                    Description = "Comprehensive guide to ASP.NET Core"
                }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FullName = "John Doe",
                    Email = "john@example.com"
                },
                new Customer
                {
                    CustomerId = 2,
                    FullName = "Jane Smith",
                    Email = "jane@example.com"
                }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    CustomerId = 1,
                    OrderDate = new DateTime(2024, 1, 15, 10, 30, 0),
                    OrderAmount = 1540.00m
                },
                new Order
                {
                    OrderId = 2,
                    CustomerId = 2,
                    OrderDate = new DateTime(2024, 2, 5, 15, 45, 0),
                    OrderAmount = 840.00m
                }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderItemId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    UnitPrice = 1500.00m
                },
                new OrderItem
                {
                    OrderItemId = 2,
                    OrderId = 1,
                    ProductId = 3,
                    Quantity = 1,
                    UnitPrice = 40.00m
                },
                new OrderItem
                {
                    OrderItemId = 3,
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 1,
                    UnitPrice = 800.00m
                },
                new OrderItem
                {
                    OrderItemId = 4,
                    OrderId = 2,
                    ProductId = 3,
                    Quantity = 1,
                    UnitPrice = 40.00m
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
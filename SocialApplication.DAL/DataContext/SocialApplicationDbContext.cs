


namespace SocialApplication.DAL.DataContext
{
    using Microsoft.EntityFrameworkCore;
    using SocialApplication.DAL.Entities;

    public class SocialApplicationDbContext : DbContext
    {
        public SocialApplicationDbContext(DbContextOptions<SocialApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Entities.DiscountTypeEntities> DiscountTypes { get; set; }
        public DbSet<Entities.OrderStatusEntities> OrderStatuses { get; set; }
        public DbSet<Entities.AddressTypeEntities> AddressTypes { get; set; }
        public DbSet<Entities.PaymentTypeEntities> PaymentTypes { get; set; }

    }
}

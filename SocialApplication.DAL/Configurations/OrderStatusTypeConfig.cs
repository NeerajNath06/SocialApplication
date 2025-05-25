using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialApplication.DAL.Entities;

namespace SocialApplication.DAL.Configurations
{
    internal class OrderStatusTypeConfig : IEntityTypeConfiguration<OrderStatusEntities>
    {
        public void Configure(EntityTypeBuilder<OrderStatusEntities> builder)
        {
            if (builder is null)
            {
                return;
            }
            builder.ToTable("ht_OrderStatusTypes");
            builder.HasKey(dt => dt.OrderStatusId);
            builder.Property(dt => dt.Description).HasColumnName("Description").HasMaxLength(500);
            builder.HasMany(d => d.Orders)
                   .WithOne(dt => dt.OrderStatus)
                   .HasForeignKey(dt => dt.OrderStatusId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: If you want to use temporal tables
        }
    }
}

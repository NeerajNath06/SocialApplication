using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialApplication.DAL.Entities;

namespace SocialApplication.DAL.Configurations
{
    internal class PaymentTypeConfig : IEntityTypeConfiguration<PaymentTypeEntities>
    {
        public void Configure(EntityTypeBuilder<PaymentTypeEntities> builder)
        {
            if (builder is null)
            {
                return;
            }
            builder.ToTable("ht_PaymentTypes");
            builder.HasKey(dt => dt.PaymentTypeId);
            builder.Property(dt => dt.Description).HasColumnName("Description").HasMaxLength(500);
            builder.HasMany(d => d.PaymentMethods)
                   .WithOne(dt => dt.PaymentType)
                   .HasForeignKey(dt => dt.PaymentTypeId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: If you want to use temporal tables
        }
    }
}

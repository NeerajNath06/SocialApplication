using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialApplication.Domain.Aggregates.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApplication.DAL.Entities;

namespace SocialApplication.DAL.Configurations
{
    internal class DiscountTypeConfig : IEntityTypeConfiguration<DiscountTypeEntities>
    {
        public void Configure(EntityTypeBuilder<DiscountTypeEntities> builder)
        {
           if (builder is null)
            {
                return;
            }
            builder.ToTable("ht_DiscountTypes");
            builder.HasKey(dt => dt.DiscountTypeId);
            builder.Property(dt => dt.Description).HasColumnName("Description").HasMaxLength(500);
            builder.HasMany(d => d.Discounts)
                   .WithOne(dt => dt.DiscountType)
                   .HasForeignKey(dt => dt.DiscountTypeId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: If you want to use temporal tables
        }
    }
}

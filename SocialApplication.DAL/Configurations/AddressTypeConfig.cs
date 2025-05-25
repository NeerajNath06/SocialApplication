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
    internal class AddressTypeConfig : IEntityTypeConfiguration<AddressTypeEntities>
    {
        public void Configure(EntityTypeBuilder<AddressTypeEntities> builder)
        {
           if (builder is null)
            {
                return;
            }
            builder.ToTable("ht_AddressTypes");
            builder.HasKey(dt => dt.AddressTypeId);
            builder.Property(dt => dt.Description).HasColumnName("Description").HasMaxLength(500);
            builder.HasMany(d => d.Addresses)
                   .WithOne(dt => dt.AddressType)
                   .HasForeignKey(dt => dt.AddressTypeId)
                   .OnDelete(DeleteBehavior.Cascade); // Optional: If you want to use temporal tables
        }
    }
}

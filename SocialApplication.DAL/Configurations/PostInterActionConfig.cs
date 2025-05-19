

namespace SocialApplication.DAL.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SocialApplication.Domain.Aggregates.Posts;
    using System;
    internal class PostInterActionConfig : IEntityTypeConfiguration<PostInteraction>
    {
        public void Configure(EntityTypeBuilder<PostInteraction> builder)
        {
            builder.HasKey(pi => pi.PostInteractionId);
        }
    }
}

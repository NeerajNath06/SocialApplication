

namespace SocialApplication.DAL.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SocialApplication.Domain.Aggregates.Posts;
    using SocialApplication.Domain.Aggregates.UserProfiles;

    internal class PostCommentConfig : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            //builder.ToTable("PostComments");
            builder.HasKey(pc => pc.PostCommentId);
            //builder.Property(pc => pc.PostCommentId).ValueGeneratedOnAdd();
            //builder.Property(pc => pc.CommentContent).IsRequired();
            //builder.Property(pc => pc.CreatedAt).IsRequired();
            //builder.Property(pc => pc.UpdatedAt).IsRequired();
            //builder.HasOne<Post>().WithMany().HasForeignKey(pc => pc.PostId);
            //builder.HasOne<UserProfile>().WithMany().HasForeignKey(pc => pc.UserProfileId);
        }
    }
}

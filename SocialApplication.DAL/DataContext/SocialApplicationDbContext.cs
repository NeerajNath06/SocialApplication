


namespace SocialApplication.DAL.DataContext
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SocialApplication.DAL.Configurations;
    using SocialApplication.Domain.Aggregates.Posts;
    using SocialApplication.Domain.Aggregates.UserProfiles;

    public class SocialApplicationDbContext : IdentityDbContext
    {
        public SocialApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Post> Posts { get; set; } // 'Post' type should be defined in the 'SocialApplication.DAL.Entities' namespace

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostCommentConfig());
            builder.ApplyConfiguration(new PostInterActionConfig());
            builder.ApplyConfiguration(new UserProfileConfig());
            builder.ApplyConfiguration(new IdentityUserLoginConfig());
            builder.ApplyConfiguration(new IdentityUserRoleConfig());
            builder.ApplyConfiguration(new IdentityUserTokenConfig());
        }
    }
}



namespace SocialApplication.Domain.Aggregates.Posts
{
    using System;

    public class PostComment
    {
        private PostComment()
        {
        }

        public Guid PostCommentId { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string? CommentContent { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }


        public static PostComment CreatePostComment(Guid postId, Guid userProfileId, string commentContent)
        {
            return new PostComment
            {
                PostId = postId,
                UserProfileId = userProfileId,
                CommentContent = commentContent,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateComment(string commentContent)
        {
            CommentContent = commentContent;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

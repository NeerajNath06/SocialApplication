

namespace SocialApplication.Domain.Aggregates.Posts
{
    using SocialApplication.Domain.Aggregates.UserProfiles;
    using System;
    using System.Collections.Generic;

    public class Post
    {
        private readonly List<PostComment> _postComments;
        private readonly List<PostInteraction> _postInteractions;
        private Post()
        {
        }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public string? PostContent { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IEnumerable<PostComment> PostComments { get { return _postComments; } }
        public IEnumerable<PostInteraction> PostInteractions { get { return _postInteractions; } }

        public static Post CreatePost(Guid userProfileId, string postContent)
        {
            return new Post
            {
                UserProfileId = userProfileId,
                PostContent = postContent,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdatePost(string postContent)
        {
            PostContent = postContent;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddComment(PostComment postComment)
        {
            _postComments.Add(postComment);
        }

        public void RemoveComment(PostComment postComment)
        {
            _postComments.Remove(postComment);
        }

        public void AddInteraction(PostInteraction postInteraction)
        {
            _postInteractions.Add(postInteraction);
        }

        public void RemoveInteraction(PostInteraction postInteraction)
        {
            _postInteractions.Remove(postInteraction);
        }
    }
}

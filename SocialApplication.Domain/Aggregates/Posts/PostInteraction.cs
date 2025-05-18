

namespace SocialApplication.Domain.Aggregates.Posts
{
    using SocialApplication.Domain.Enums;
    using System;

    public class PostInteraction
    {
        private PostInteraction()
        {
        }
        public Guid PostInteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }

        public static PostInteraction CreatePostInteraction(Guid postId, InteractionType interactionType)
        {
            return new PostInteraction
            {
                PostId = postId,
                InteractionType = interactionType
            };
        }
    }
}

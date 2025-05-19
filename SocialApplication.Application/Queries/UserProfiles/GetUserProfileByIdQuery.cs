

namespace SocialApplication.Application.Queries.UserProfiles
{
    using MediatR;
    using SocialApplication.Domain.Aggregates.UserProfiles;
    using System;
    public class GetUserProfileByIdQuery : IRequest<UserProfile>
    {
        public Guid ProfileId { get; set; }
    }
}



namespace SocialApplication.Application.AutoMappers
{
    using AutoMapper;
    using SocialApplication.Application.Commands.UserProfiles;
    using SocialApplication.Domain.Aggregates.UserProfiles;

    internal class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<AddUserProfileCommand, UserInfo>();
        }
    }
}

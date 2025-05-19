

namespace SocialApplication.API.AutoMappers
{
    using AutoMapper;
    using SocialApplication.API.Contracts.UserProfiles.Requests;
    using SocialApplication.API.Contracts.UserProfiles.Responcses;
    using SocialApplication.Application.Commands.UserProfiles;
    using SocialApplication.Domain.Aggregates.UserProfiles;

    internal class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<AddUserProfile, AddUserProfileCommand>();
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfile, UserInfoDto>();
        }
    }
}

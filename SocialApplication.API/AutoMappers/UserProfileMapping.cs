

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
            CreateMap<AddUpdateUserProfile, AddUserProfileCommand>();
            CreateMap<AddUpdateUserProfile, UpdateUserProfileByIdCommand>();
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserInfo, UserInfoDto>();
        }
    }
}

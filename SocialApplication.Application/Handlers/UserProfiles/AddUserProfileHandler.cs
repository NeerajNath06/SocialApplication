

namespace SocialApplication.Application.Handlers.UserProfiles
{
    using AutoMapper;
    using MediatR;
    using SocialApplication.Application.Commands.UserProfiles;
    using SocialApplication.DAL.DataContext;
    using SocialApplication.Domain.Aggregates.UserProfiles;
    using System;
    using System.Threading.Tasks;
    internal class AddUserProfileHandler : IRequestHandler<AddUserProfileCommand, UserProfile>
    {
        private readonly SocialApplicationDbContext _dbContext;
        public AddUserProfileHandler(SocialApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserProfile> Handle(AddUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = UserInfo.CreateUserInfo(
                request.FirstName,
                request.LastName,
                request.EmailAddress,
                request.PhoneNumber,
                request.Address,
                request.CurrentCity,
                request.DateOfBirth
            );

            var userProfileEntity = UserProfile.CreateUserProfile(
                Guid.NewGuid().ToString(), 
                userProfile
                );

            await _dbContext.UserProfiles.AddAsync(userProfileEntity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return userProfileEntity;
        }
    }
}



namespace SocialApplication.Application.Handlers.UserProfiles
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using SocialApplication.Application.Commands.UserProfiles;
    using SocialApplication.DAL.DataContext;
    using SocialApplication.Domain.Aggregates.UserProfiles;
    using System;
    using System.Threading.Tasks;
    internal class UpdateUserProfileByIdHandler : IRequestHandler<UpdateUserProfileByIdCommand, Unit>
    {
        private readonly SocialApplicationDbContext _dbContext;
        public UpdateUserProfileByIdHandler(SocialApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserProfileByIdCommand request, CancellationToken cancellationToken)
        {
            // Implementation for updating a user profile by ID
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.UserId == request.ProfileId, cancellationToken);
            
            var userInfo = UserInfo.CreateUserInfo(
                request.FirstName,
                request.LastName,
                request.EmailAddress,
                request.PhoneNumber,
                request.Address,
                request.CurrentCity,
                request.DateOfBirth
            );
            if (userProfile == null)
            {
                throw new Exception($"User profile with ID {request.ProfileId} not found.");
            }

            userProfile.UpdateUserInfo(userInfo);
            _dbContext.UserProfiles.Update(userProfile);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

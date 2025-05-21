using MediatR;
using SocialApplication.Application.Commands.UserProfiles;
using SocialApplication.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Handlers.UserProfiles
{
    internal class DeleteUserProfileHandler : IRequestHandler<DeleteUserProfileCommand, Unit>
    {
        private readonly SocialApplicationDbContext _dbContext;
        public DeleteUserProfileHandler(SocialApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            // Implementation for deleting a user profile by ID
            var userProfile = _dbContext.UserProfiles
                .FirstOrDefault(up => up.UserId == request.ProfileId) ?? throw new Exception($"User profile with ID {request.ProfileId} not found.");

            _dbContext.UserProfiles.Remove(userProfile);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

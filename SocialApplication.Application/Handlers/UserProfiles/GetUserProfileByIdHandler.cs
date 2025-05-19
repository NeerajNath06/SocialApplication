using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialApplication.Application.Queries.UserProfiles;
using SocialApplication.DAL.DataContext;
using SocialApplication.Domain.Aggregates.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Handlers.UserProfiles
{
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
    {
        private readonly SocialApplicationDbContext _dbContext;
        public GetUserProfileByIdHandler(SocialApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _dbContext.UserProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(up => up.UserId == request.ProfileId, cancellationToken);
            
            if (userProfile == null)
            {
                throw new Exception($"User profile with ID {request.ProfileId} not found.");
            }

            return userProfile;
        }
    }
}

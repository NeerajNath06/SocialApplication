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
    internal class GetAllUerProfilesHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly SocialApplicationDbContext _dbcontext; // Updated to use the correct DbContext type  

        public GetAllUerProfilesHandler(SocialApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var userProfiles = await _dbcontext.UserProfiles
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return userProfiles;
        }
    }
}

using MediatR;
using SocialApplication.Domain.Aggregates.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Queries.UserProfiles
{
    public class GetAllUserProfilesQuery : IRequest<IEnumerable<UserProfile>>
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Commands.UserProfiles
{
    public class DeleteUserProfileCommand : IRequest<Unit>
    {
        public Guid ProfileId { get; set; }
    }
}

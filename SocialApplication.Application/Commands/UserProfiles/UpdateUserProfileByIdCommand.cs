using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Commands.UserProfiles
{
    public class UpdateUserProfileByIdCommand : IRequest<Unit>
    {
        public Guid ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CurrentCity { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}

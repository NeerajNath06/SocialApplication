

namespace SocialApplication.Application.Commands.UserProfiles
{
    using MediatR;
    using SocialApplication.Application.ErrorModels;
    using SocialApplication.Domain.Aggregates.UserProfiles;
    using System;
    public class UpdateUserProfileByIdCommand : IRequest<OperationsResult<UserProfile>>
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

﻿namespace SocialApplication.API.Contracts.UserProfiles.Requests
{
    public record AddUpdateUserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CurrentCity { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}

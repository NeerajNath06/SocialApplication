

namespace SocialApplication.Domain.Aggregates.UserProfiles
{
    using System;

    public class UserInfo
    {
        private UserInfo()
        {

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string CurrentCity { get; private set; }
        public DateOnly DateOfBirth { get; private set; }

        public static UserInfo CreateUserInfo(string firstName, string lastName, string emailAddress, string phoneNumber, string address, string currentCity, DateOnly dateOfBirth)
        {
            return new UserInfo
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                Address = address,
                CurrentCity = currentCity,
                DateOfBirth = dateOfBirth
            };
        }
    }
}

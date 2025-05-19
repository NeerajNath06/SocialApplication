namespace SocialApplication.API.Contracts.UserProfiles.Responcses
{
    public record UserInfoDto
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

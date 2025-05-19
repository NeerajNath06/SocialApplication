namespace SocialApplication.API.Contracts.UserProfiles.Responcses
{
    public record UserProfileDto
    {
        public Guid UserId { get; set; }
        public UserInfoDto UserInfo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

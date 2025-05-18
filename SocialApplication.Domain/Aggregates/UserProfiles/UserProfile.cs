namespace SocialApplication.Domain.Aggregates.UserProfiles
{
    using System;
    public class UserProfile
    {
        private UserProfile()
        {
            
        }
        public Guid UserId { get; private set; }
        public string? UserIdentityId { get; private set; }
        public UserInfo UserInfo { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Factory method to create a new UserProfile instance. and handle the validation of the UserInfo object.
        /// </summary>
        /// <param name="userIdentity"></param>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static UserProfile CreateUserProfile(string userIdentity, UserInfo userInfo)
        {
            return new UserProfile
            {
                UserIdentityId = userIdentity,
                UserInfo = userInfo,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            UserInfo = userInfo;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

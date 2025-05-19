namespace SocialApplication.API.ApiRoutes
{
    public class ApiRoute
    {
        public const string BaseRoute = "api/v{version:apiVersion}/[controller]";
        public class UserProfiles
        {
            public const string IdRoute = "{id}";
            public const string Create = "AddUserProfile";
            public const string GetAll = "GetAllUserProfiles";
        }
        public class Posts
        {
            public const string GetById = "{id}";
        }
    }
}

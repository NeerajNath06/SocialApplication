using SocialApplication.API.Options;
using SocialApplication.API.Registars.Interfaces;

namespace SocialApplication.API.Registars.ImplementedClasses
{
    public class SwaggerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();

            /// <summary>
            /// Add Versioning to the Swagger Page to display the Versions of the API
            /// </summary>
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}

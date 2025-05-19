using Microsoft.Extensions.DependencyInjection;
using SocialApplication.API.Registars.Interfaces;
using SocialApplication.Application.Queries.UserProfiles;

namespace SocialApplication.API.Registars.RegistrarClasses
{
    public class HandlerQueryRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            // Register MediatR handlers
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfilesQuery));
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<GetAllUserProfilesQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetUserProfileByIdQuery>();
            });
            // Register other services as needed
            // For example, if you have a DbContext, you can register it here

        }
    }
}

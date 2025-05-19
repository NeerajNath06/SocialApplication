

namespace SocialApplication.API.Registars.RegistrarClasses
{
    using Microsoft.EntityFrameworkCore;
    using SocialApplication.API.Registars.Interfaces;
    using SocialApplication.DAL.DataContext;

    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SocialApplicationDbContext>(Options=> Options.UseSqlServer(connectionString));
        }
    }
}


namespace SocialApplication.API.Registars.ImplementedClasses
{
    using SocialApplication.API.Registars.Interfaces;

    public class MvcWebApplicationRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}

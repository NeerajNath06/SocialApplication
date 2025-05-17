
namespace SocialApplication.API.Registars.ImplementedClasses
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using SocialApplication.API.Registars.Interfaces;

    public class SwaggerWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root);
                });

            }
        }
    }
}

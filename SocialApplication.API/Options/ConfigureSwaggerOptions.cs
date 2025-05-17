namespace SocialApplication.API.Options
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
        public void Configure(SwaggerGenOptions options)
        {
            // Add custom operation filters or document filters here if needed
            // For example, you can add a filter to include XML comments in the Swagger UI
            // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "YourApi.xml"));

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Social Application API",
                Version = description.ApiVersion.ToString(),
                Description = "Clean Architecture With CQRS ASP.NET Core Web API"
            };
            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }
            return info;
        }
    }
}

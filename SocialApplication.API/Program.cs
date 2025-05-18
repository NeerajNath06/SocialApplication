using SocialApplication.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Call to RegistrationService

builder.ResterServices(typeof(Program));

var app = builder.Build();

app.RegisterPipelineComponents(typeof(Program));
app.Run();

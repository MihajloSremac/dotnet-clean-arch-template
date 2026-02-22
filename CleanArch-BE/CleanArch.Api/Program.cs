using CleanArch.Application;
using CleanArch.Infrastructure;
using CleanArch.Api;
using CleanArch.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddJwtAuthentication(configuration);

// TODO: restrict AllowAnyOrigin to specific frontend URL in production
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();

var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
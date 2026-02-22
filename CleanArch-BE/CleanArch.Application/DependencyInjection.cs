using Microsoft.Extensions.DependencyInjection;
using CleanArch.Application.Contracts.UseCases.Auth;
using CleanArch.Application.Contracts.UseCases.Users;
using CleanArch.Application.UseCases.Auth;
using CleanArch.Application.UseCases.Users;

namespace CleanArch.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}
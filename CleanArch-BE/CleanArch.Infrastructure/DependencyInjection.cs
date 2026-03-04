using CleanArch.Infrastructure.Persistence;
using CleanArch.Infrastructure.Persistence.Users;
using CleanArch.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArch.Application.Contracts.Infrastructure;
using CleanArch.Application.Contracts.Persistence;

namespace CleanArch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        //Services
        services.AddSingleton<ITokenService, TokenService>();

        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}

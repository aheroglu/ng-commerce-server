using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Server.Domain.Entities;
using Server.Domain.Repositories;
using Server.Infrastructure.Context;
using Server.Infrastructure.Options.Email;
using Server.Infrastructure.Options.Jwt;

namespace Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services
            .AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

        services
            .AddIdentityCore<AppUser>()
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        services
            .Configure<JwtOptions>(configuration.GetSection("JWT"));

        services
            .ConfigureOptions<JwtSetupOptions>();

        services
            .Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services
            .AddMemoryCache();

        services
            .AddAuthentication()
            .AddJwtBearer();

        services
            .AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            });

        services
            .AddScoped<IUnitOfWork>(options =>
                options.GetRequiredService<AppDbContext>());

        services
            .Scan(action =>
            {
                action
                    .FromAssemblies(assembly)
                    .AddClasses(false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

        return services;
    }
}
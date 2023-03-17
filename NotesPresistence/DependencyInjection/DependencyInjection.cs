using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace NotesPresistence.DependencyInjection;

/// <summary>
/// Class DependencyInjection.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the persistence.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<NotesDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>()!);
        return services;
    }
}
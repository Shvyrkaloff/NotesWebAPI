﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace NotesPresistence;

public static class DependencyInjection
{
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
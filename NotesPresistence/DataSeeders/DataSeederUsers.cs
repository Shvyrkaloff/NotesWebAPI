using Microsoft.EntityFrameworkCore;
using NotesPresistence.Entities;

namespace NotesPresistence.DataSeeders;

/// <summary>
/// Class DataSeederUsers.
/// </summary>
public static class DataSeederUsers
{
    /// <summary>
    /// Seeds the data.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    /// <returns>ModelBuilder.</returns>
    public static ModelBuilder SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = Guid.Empty.ToString(),
            Login = "Default",
            Password = "Default"
        });

        return modelBuilder;
    }
}
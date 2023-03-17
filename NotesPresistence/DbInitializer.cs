namespace NotesPresistence;

/// <summary>
/// Class DbInitializer.
/// </summary>
public class DbInitializer
{
    /// <summary>
    /// Initializes the specified context.
    /// </summary>
    /// <param name="context">The context.</param>
    public static void Initialize(NotesDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
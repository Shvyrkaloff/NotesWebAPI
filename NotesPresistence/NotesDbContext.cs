using Microsoft.EntityFrameworkCore;
using NotesPresistence.Entities;
using NotesPresistence.EntityTypeConfigurations;

namespace NotesPresistence;

/// <summary>
/// Class NotesDbContext.
/// Implements the <see cref="DbContext" />
/// Implements the <see cref="NotesPresistence.INotesDbContext" />
/// </summary>
/// <seealso cref="DbContext" />
/// <seealso cref="NotesPresistence.INotesDbContext" />
public class NotesDbContext : DbContext, INotesDbContext
{
    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    public DbSet<Note> Notes { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotesDbContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        : base(options) { }

    /// <summary>
    /// Called when [model creating].
    /// </summary>
    /// <param name="builder">The builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new NoteConfiguration());

        base.OnModelCreating(builder);
    }
}
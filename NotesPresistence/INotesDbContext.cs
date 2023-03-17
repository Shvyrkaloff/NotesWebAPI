using Microsoft.EntityFrameworkCore;
using NotesPresistence.Entities;

namespace NotesPresistence;

/// <summary>
/// Interface INotesDbContext
/// </summary>
public interface INotesDbContext
{
    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    DbSet<Note> Notes { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    DbSet<User> Users { get; set; }

    /// <summary>
    /// Saves the changes asynchronous.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;System.Int32&gt;.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
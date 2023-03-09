using Microsoft.EntityFrameworkCore;

namespace NotesPresistence;

public interface INotesDbContext
{
    DbSet<Note> Notes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
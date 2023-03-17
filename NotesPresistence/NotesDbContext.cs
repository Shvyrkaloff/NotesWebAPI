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
    /// Initializes a new instance of the <see cref="NotesDbContext" /> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        : base(options) { }

    /// <summary>
    /// Override this method to configure the database (and other options) to be used for this context.
    /// This method is called for each instance of the context that is created.
    /// The base implementation does nothing.
    /// </summary>
    /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
    /// typically define extension methods on this object that allow you to configure the context.</param>
    /// <remarks><para>
    /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
    /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
    /// the options have already been set, and skip some or all of the logic in
    /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    /// for more information and examples.
    /// </para></remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

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
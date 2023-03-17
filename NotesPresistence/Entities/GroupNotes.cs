using NotesPresistence.Base;

namespace NotesPresistence.Entities;

/// <summary>
/// Class GroupNotes.
/// Implements the <see cref="IHaveId" />
/// </summary>
/// <seealso cref="IHaveId" />
public class GroupNotes : IHaveId
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    public virtual List<Note>? Notes { get; set; }
}
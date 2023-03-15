using System.Text.Json.Serialization;

namespace NotesPresistence;

/// <summary>
/// Class Note.
/// </summary>
public class Note
{
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the details.
    /// </summary>
    /// <value>The details.</value>
    public string? Details { get; set; }

    /// <summary>
    /// Gets or sets the creation date.
    /// </summary>
    /// <value>The creation date.</value>
    [JsonIgnore]
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets or sets the edit date.
    /// </summary>
    /// <value>The edit date.</value>
    [JsonIgnore]
    public DateTime? EditDate { get; set; }
}
﻿using System.Text.Json.Serialization;
using NotesPresistence.Base;

namespace NotesPresistence.Entities;

/// <summary>
/// Class Note.
/// </summary>
public class Note : IHaveId
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

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

    /// <summary>
    /// Gets or sets a value indicating whether this instance is important.
    /// </summary>
    /// <value><c>true</c> if this instance is important; otherwise, <c>false</c>.</value>
    public bool IsImportant { get; set; }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    public virtual User? User { get; set; }

    /// <summary>
    /// Gets or sets the group notes identifier.
    /// </summary>
    /// <value>The group notes identifier.</value>
    public string? GroupNotesId { get; set; }

    /// <summary>
    /// Gets or sets the group notes.
    /// </summary>
    /// <value>The group notes.</value>
    public virtual GroupNotes? GroupNotes { get; set; }
}
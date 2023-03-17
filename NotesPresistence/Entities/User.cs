using System.Diagnostics.CodeAnalysis;
using NotesPresistence.Base;

namespace NotesPresistence.Entities;

/// <summary>
/// Class User.
/// Implements the <see cref="IHaveId" />
/// </summary>
/// <seealso cref="IHaveId" />
public class User : IHaveId
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the login.
    /// </summary>
    /// <value>The login.</value>
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [AllowNull]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    public virtual List<Note>? Notes { get; set; }
}
using MediatR;

namespace NotesApplication.Notes.Commands.CreateNote;

/// <summary>
/// Class CreateNoteCommand.
/// Implements the <see cref="MediatR.IRequest{System.String}" />
/// </summary>
/// <seealso cref="MediatR.IRequest{System.String}" />
public class CreateNoteCommand : IRequest<string>
{
    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    public string? UserId { get; set; }

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
}
using MediatR;
using NotesPresistence;

namespace NotesApplication.Notes.Commands.CreateNote;

/// <summary>
/// Class CreateNoteCommndHandler.
/// Implements the <see cref="MediatR.IRequestHandler{NotesApplication.Notes.Commands.CreateNote.CreateNoteCommand, System.String}" />
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{NotesApplication.Notes.Commands.CreateNote.CreateNoteCommand, System.String}" />
public class CreateNoteCommndHandler :IRequestHandler<CreateNoteCommand, string>
{
    /// <summary>
    /// The database context
    /// </summary>
    private readonly  INotesDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateNoteCommndHandler"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    public CreateNoteCommndHandler(INotesDbContext dbContext) => _dbContext = dbContext;

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<string> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserId.ToString(),
            Title = request.Title,
            Details = request.Details,
            Id = Guid.NewGuid().ToString(),
            CreationDate = DateTime.Now,
            EditDate = null
        };
        await _dbContext.Notes.AddAsync(note, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return note.Id.ToString();
    }
}
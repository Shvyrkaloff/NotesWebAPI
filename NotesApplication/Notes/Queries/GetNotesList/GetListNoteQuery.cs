using MediatR;

namespace NotesApplication.Notes.Queries.GetNotesList;

public record GetListNoteQuery : IRequest<NoteListVm>
{
    public string? UserId { get; set; }
}
using MediatR;

namespace NotesWebApi.Notes.Queries.GetNotesList;

public record GetListNoteQuery(string? UserId) : IRequest<List<NoteLookUpDto>?>;
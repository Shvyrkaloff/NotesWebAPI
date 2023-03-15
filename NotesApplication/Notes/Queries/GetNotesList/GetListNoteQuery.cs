using MediatR;
using NotesPresistence;

namespace NotesApplication.Notes.Queries.GetNotesList;

public record GetListNoteQuery(string? UserId) : IRequest<List<NoteLookUpDto>?>;
using MediatR;
using NotesPresistence.Entities;

namespace NotesApplication.Notes.Queries.GetNotesList;

public record GetListNoteQuery(string? UserId) : IRequest<List<NoteLookUpDto>?>;
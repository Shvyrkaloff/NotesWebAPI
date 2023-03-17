using MediatR;
using NotesPresistence.Dto;

namespace NotesApplication.Notes.Queries.GetNotesList;

public record GetListNoteQuery(string? UserId) : IRequest<List<NoteLookUpDto>?>;
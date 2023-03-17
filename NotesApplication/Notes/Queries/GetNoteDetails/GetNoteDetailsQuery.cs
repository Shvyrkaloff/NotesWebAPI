using MediatR;
using NotesPresistence.Entities;

namespace NotesApplication.Notes.Queries.GetNoteDetails;

public record GetNoteDetailsQuery(string? UserId, string Id) :  IRequest<List<NoteDetailsVm>?>;


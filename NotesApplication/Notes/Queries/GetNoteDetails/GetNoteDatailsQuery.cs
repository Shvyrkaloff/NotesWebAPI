using MediatR;
using NotesPresistence;

namespace NotesApplication.Notes.Queries.GetNoteDetails;
public record GetNoteDatailsQuery(string? UserId, string Id) :  IRequest<List<NoteDetailsVm>?>;


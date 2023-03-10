using MediatR;

namespace NotesWebApi.Notes.Queries.GetNoteDetails;
public record GetNoteDatailsQuery(string? UserId, string Id) :  IRequest<List<NoteDetailsVm>?>;


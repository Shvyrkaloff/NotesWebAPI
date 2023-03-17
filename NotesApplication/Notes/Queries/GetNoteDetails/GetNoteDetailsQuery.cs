using MediatR;
using NotesPresistence.Dto;

namespace NotesApplication.Notes.Queries.GetNoteDetails;

public record GetNoteDetailsQuery(string? UserId, string Id) :  IRequest<NoteDetailsVm>;


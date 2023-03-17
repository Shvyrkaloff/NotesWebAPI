using AutoMapper;
using MediatR;
using NotesApplication.Data;
using NotesPresistence.Dto;
using NotesPresistence.Entities;

namespace NotesApplication.Notes.Queries.GetNoteDetails;

/// <summary>
/// Class GetNoteDetailsQueryHandler.
/// Implements the <see cref="MediatR.IRequestHandler{NotesApplication.Notes.Queries.GetNoteDetails.GetNoteDetailsQuery, NotesPresistence.Dto.NoteDetailsVm}" />
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{NotesApplication.Notes.Queries.GetNoteDetails.GetNoteDetailsQuery, NotesPresistence.Dto.NoteDetailsVm}" />
public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
    /// <summary>
    /// The repository
    /// </summary>
    private readonly IRepository<Note> _repository;

    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetNoteDetailsQueryHandler" /> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetNoteDetailsQueryHandler(IRepository<Note> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
    {
        var detailsQuery = _repository.Find(request.Id);

        return _mapper.Map(detailsQuery, new NoteDetailsVm());
    }
}
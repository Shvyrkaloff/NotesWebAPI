using AutoMapper;
using MediatR;
using NotesApplication.Data;
using NotesPresistence.Entities;

namespace NotesApplication.Notes.Queries.GetNotesList;

/// <summary>
/// Class GetListNoteQueryHandler.
/// Implements the <see cref="MediatR.IRequestHandler{NotesApplication.Notes.Queries.GetNotesList.GetListNoteQuery, System.Collections.Generic.List{NoteLookUpDto}}" />
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{NotesApplication.Notes.Queries.GetNotesList.GetListNoteQuery, System.Collections.Generic.List{NoteLookUpDto}}" />
public class GetListNoteQueryHandler : IRequestHandler<GetListNoteQuery, List<NoteLookUpDto>?>
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
    /// Initializes a new instance of the <see cref="GetListNoteQueryHandler"/> class.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetListNoteQueryHandler(IRepository<Note> repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<List<NoteLookUpDto>?> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
    {
        var notesQuery = _repository.GetAll().ToList();

        return _mapper.Map(notesQuery, new List<NoteLookUpDto>());
    }
}
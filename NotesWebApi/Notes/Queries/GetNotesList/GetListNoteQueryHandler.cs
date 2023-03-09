using AutoMapper;
using MediatR;
using NotesPresistence;
using NotesWebApi.Data;

namespace NotesWebApi.Notes.Queries.GetNotesList;

public class GetListNoteQueryHandler : IRequestHandler<GetListNoteQuery, List<NoteLookUpDto>?>
{
    private readonly IRepository<Note> _repository;

    private readonly IMapper _mapper;

    public GetListNoteQueryHandler(IRepository<Note> repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    public async Task<List<NoteLookUpDto>?> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
    {
        var notesQuery = _repository.GetAll().ToList();

        return _mapper.Map(notesQuery, new List<NoteLookUpDto>());
    }
}
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Common.Exception;
using NotesPresistence;
using NotesWebApi.Data;

namespace NotesWebApi.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDatailsQuery, List<NoteDetailsVm>?>
    {
        private readonly IRepository<Note> _repository;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(IRepository<Note> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);
        public async Task<List<NoteDetailsVm>?> Handle(GetNoteDatailsQuery request, CancellationToken cancellationToken)
        {
            var detailsQuery = _repository.GetAll().ToList();
            
            return _mapper.Map(detailsQuery, new List<NoteDetailsVm>());
        }
    }
}

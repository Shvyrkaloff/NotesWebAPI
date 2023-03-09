using NotesApplication.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace NotesApplication.Notes.Queries.GetNotesList;

public class GetListNoteQueryHandler : IRequestHandler<GetListNoteQuery, NoteListVm>
{
    private readonly INotesDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetListNoteQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<NoteListVm> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.Notes.Where(note => note.UserId == request.UserId.ToString())
            .ProjectTo<NoteLookUpDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        return new NoteListVm { Notes = notesQuery };
    }
}
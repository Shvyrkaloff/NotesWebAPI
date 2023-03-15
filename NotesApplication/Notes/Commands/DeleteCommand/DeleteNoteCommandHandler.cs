using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Common.Exception;
using NotesPresistence;

namespace NotesApplication.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INotesDbContext _dbContext;
        public DeleteNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id.ToString(), cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }
            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return  Unit.Value;
        }
    }
}

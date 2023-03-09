using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NotesApplication.Interfaces;
using NotesDomain;

namespace NotesApplication.Notes.Commands.CreateNote
{
    public class CreateNoteCommndHandler :IRequestHandler<CreateNoteCommand, string>
    {
        private  readonly  INotesDbContext _dbContext;
        public CreateNoteCommndHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<string> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId.ToString(),
                Title = request.Title,
                Deatails = request.Details,
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                EditDate = null
            };
            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return note.Id.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NotesApplication.Notes.Queries.GetNotesList
{
    public class GetListNoteQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}

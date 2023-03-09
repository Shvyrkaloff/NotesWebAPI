using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries.GetNotesList
{
    public class NoteListVm
    {
        public IList<NoteLookUpDto> Notes { get; set; }
    }
}

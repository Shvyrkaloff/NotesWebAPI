using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NotesApplication.Interfaces;
using NotesApplication.Notes.Queries.GetNoteDetails;


namespace NotesApplication.Notes.Queries.GetNoteDetails
{
    public class GetNoteDatailsQuery : IRequest<NoteDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}

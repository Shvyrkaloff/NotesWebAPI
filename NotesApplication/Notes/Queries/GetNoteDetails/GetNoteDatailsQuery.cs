﻿using MediatR;


namespace NotesApplication.Notes.Queries.GetNoteDetails
{
    public class GetNoteDatailsQuery : IRequest<NoteDetailsVm>
    {
        public string UserId { get; set; }
        public string Id { get; set; }
    }
}

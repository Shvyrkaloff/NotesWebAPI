using NotesPresistence.Entities;

namespace NotesApplication.Notes.Queries.GetNotesList;

public class NoteListVm
{
    public List<NoteLookUpDto>? Notes { get; set; }
}
using NotesPresistence;

namespace NotesWebApi.Notes.Queries.GetNotesList;

public class NoteListVm
{
    public List<NoteLookUpDto>? Notes { get; set; }
}
using MediatR;

namespace NotesApplication.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<string>
    {
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}

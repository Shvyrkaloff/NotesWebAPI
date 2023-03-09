using MediatR;

namespace NotesWebApi.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public  string UserId { get; set; }
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
    }
}

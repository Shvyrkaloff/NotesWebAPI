using MediatR;

namespace NotesWebApi.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommand : IRequest<Unit>
    {
        public string UserId { get; set; }
        public string Id { get; set; }
    }
}

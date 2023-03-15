using NotesPresistence;

namespace WebClient.Services;

public interface INoteService
{
    public Task<List<NoteLookUpDto>?> GetAll();
}
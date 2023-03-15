using NotesApplication.Models;
using NotesPresistence;

namespace WebClient.Services;

/// <summary>
/// Interface INoteService
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.Nullable&lt;List&lt;NoteLookUpDto&gt;&gt;&gt;.</returns>
    public Task<List<NoteLookUpDto>?> GetAllAsync();

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
    public Task<HttpResponseMessage> DeleteAsync(string id);

    public Task<HttpResponseMessage> CreateAsync(CreateNoteDto note);
}
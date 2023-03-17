using NotesApplication.Models;
using NotesPresistence.Dto;

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
    /// Gets the identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;System.Nullable&lt;NoteDetailsVm&gt;&gt;.</returns>
    public Task<NoteDetailsVm?> GetIdAsync(string id);

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
    public Task<HttpResponseMessage> DeleteAsync(string id);

    /// <summary>
    /// Creates the asynchronous.
    /// </summary>
    /// <param name="note">The note.</param>
    /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
    public Task<HttpResponseMessage> CreateAsync(CreateNoteDto note);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="note">The note.</param>
    /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
    public Task<HttpResponseMessage> UpdateAsync(UpdateNoteDto note);
}
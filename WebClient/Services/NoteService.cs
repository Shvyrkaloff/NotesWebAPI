using NotesApplication.Models;
using NotesPresistence;

namespace WebClient.Services;

/// <summary>
/// Class NoteService.
/// Implements the <see cref="WebClient.Services.INoteService" />
/// </summary>
/// <seealso cref="WebClient.Services.INoteService" />
public class NoteService : INoteService
{
    /// <summary>
    /// The HTTP client
    /// </summary>
    private readonly HttpClient? _httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="NoteService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client.</param>
    public NoteService(HttpClient? httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Get all as an asynchronous operation.
    /// </summary>
    /// <returns>A Task&lt;List`1&gt; representing the asynchronous operation.</returns>
    public async Task<List<NoteLookUpDto>?> GetAllAsync()
    {
        var result = await _httpClient?.GetFromJsonAsync<List<NoteLookUpDto>>("api/note")!;
        return result;
    }

    /// <summary>
    /// Get identifier as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;NoteDetailsVm&gt; representing the asynchronous operation.</returns>
    public async Task<NoteDetailsVm?> GetIdAsync(string id)
    {
        var result = await _httpClient!.GetFromJsonAsync<NoteDetailsVm>($"api/Note/{id}");
        return result;
    }

    /// <summary>
    /// Delete as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public async Task<HttpResponseMessage> DeleteAsync(string id)
    {
        var result = await _httpClient?.DeleteAsync($"api/note/{id}")!;
        return result;
    }

    /// <summary>
    /// Create as an asynchronous operation.
    /// </summary>
    /// <param name="note">The note.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public async Task<HttpResponseMessage> CreateAsync(CreateNoteDto note)
    {
        var result = await _httpClient?.PostAsJsonAsync<CreateNoteDto>("api/note", note)!;
        return result;
    }

    /// <summary>
    /// Update as an asynchronous operation.
    /// </summary>
    /// <param name="note">The note.</param>
    /// <returns>A Task&lt;HttpResponseMessage&gt; representing the asynchronous operation.</returns>
    public async Task<HttpResponseMessage> UpdateAsync(UpdateNoteDto note)
    {
        var result = await _httpClient?.PutAsJsonAsync<UpdateNoteDto>("api/note", note)!;
        return result;
    }
}
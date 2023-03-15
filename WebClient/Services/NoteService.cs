using NotesApplication.Models;
using NotesPresistence;

namespace WebClient.Services;

public class NoteService : INoteService
{
    private readonly HttpClient? _httpClient;

    public NoteService(HttpClient? httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<NoteLookUpDto>?> GetAllAsync()
    {
        var result = await _httpClient?.GetFromJsonAsync<List<NoteLookUpDto>>("api/note")!;
        return result;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string id)
    {
        var result = await _httpClient?.DeleteAsync($"api/note/{id}")!;
        return result;
    }

    public async Task<HttpResponseMessage> CreateAsync(CreateNoteDto note)
    {
        var result = await _httpClient?.PostAsJsonAsync<CreateNoteDto>("api/note", note)!;
        return result;
    }
}
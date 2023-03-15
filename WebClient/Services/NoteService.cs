using Microsoft.AspNetCore.Mvc;
using NotesPresistence;

namespace WebClient.Services;

public class NoteService : INoteService
{
    private readonly HttpClient? _httpClient;

    public NoteService(HttpClient? httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ActionResult<NoteDetailsVm>> GetAll()
    {
        var result = await _httpClient?.GetFromJsonAsync<ActionResult<NoteDetailsVm>>("api/note")!;
        return result;
    }
}
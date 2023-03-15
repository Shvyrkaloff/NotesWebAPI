using Microsoft.AspNetCore.Mvc;
using NotesPresistence;

namespace WebClient.Services;

public interface INoteService
{
    public Task<ActionResult<NoteDetailsVm>> GetAll();
}
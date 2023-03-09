using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
namespace NotesWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase

{
    public string? UserId => !User.Identity!.IsAuthenticated
        ? Guid.Empty.ToString()
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!).ToString();
}
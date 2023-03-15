using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Models;
using NotesApplication.Notes.Commands.CreateNote;
using NotesApplication.Notes.Commands.DeleteCommand;
using NotesApplication.Notes.Commands.UpdateNote;
using NotesApplication.Notes.Queries.GetNoteDetails;
using NotesApplication.Notes.Queries.GetNotesList;
using NotesPresistence;

namespace NotesWebApi.Controllers;

/// <summary>
/// Class NoteController.
/// Implements the <see cref="NotesWebApi.Controllers.BaseController" />
/// </summary>
/// <seealso cref="NotesWebApi.Controllers.BaseController" />
[Produces("application/json")]
[Route("api/[controller]")]
public class NoteController : BaseController
{
    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// The mediator
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="NoteController" /> class.
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="mediator">The mediator.</param>
    public NoteController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>ActionResult&lt;NoteDetailsVm&gt;.</returns>
    [HttpGet]
    public async Task<List<NoteLookUpDto>?> GetAll()
    {
        var vm = await _mediator.Send(new GetListNoteQuery(UserId));
        return vm;
    }

    /// <summary>
    /// Gets the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult&lt;NoteDetailsVm&gt;.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDetailsVm>> Get(string id)
    {
        var query = new GetNoteDatailsQuery(UserId, id);
        var vm = await _mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Creates the specified create note dto.
    /// </summary>
    /// <param name="note">The create note dto.</param>
    /// <returns>ActionResult&lt;System.String&gt;.</returns>
    [HttpPost]
    public async Task<ActionResult<string>> Create(CreateNoteDto note)
    {
        //todo: correct map
        //var command = _mapper.Map<CreateNoteCommand>(note);
        var command = new CreateNoteCommand()
        {
            Title = note.Title,
            Details = note.Details
        };
        if (UserId != null)
            command.UserId = UserId;
        var noteId = await _mediator.Send(command);
        return Ok(noteId);
    }

    /// <summary>
    /// Updates the specified update note dto.
    /// </summary>
    /// <param name="updateNoteDto">The update note dto.</param>
    /// <returns>ActionResult.</returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
    {
        var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
        if (UserId != null) 
            command.UserId = UserId;
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>ActionResult.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var command = new DeleteNoteCommand
        {
            Id = id,
            UserId = UserId
        };
        await _mediator.Send(command);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Notes.Queries.GetNoteDetails;
using NotesApplication.Notes.Queries.GetNotesList;
using NotesApplication.Notes.Commands.CreateNote;
using NotesApplication.Notes.Commands.UpdateNote;
using NotesApplication.Notes.Commands.DeleteCommand;
using AutoMapper;
using MediatR;
using NotesWebApi.Models;

namespace NotesWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public NoteController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<NoteDetailsVm>> GetAll()
        {
            var vm = await _mediator.Send(new GetListNoteQuery());
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get(string id)
        {
            var query = new GetNoteDatailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = await Mediator.Send(command);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

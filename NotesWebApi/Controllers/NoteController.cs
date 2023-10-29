using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Notes.Commands;
using NotesApplication.Notes.Queries;
using NotesWebApi.Models;

namespace NotesWebApi.Controllers
{
    [Route("api/note")]
    public class NoteController: BaseController
    {
        private readonly IMapper _mapper;
        
        public NoteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<NoteListViewModel>> GetList()
        {
            GetNotesListQuery query = new GetNotesListQuery
            {
                userID = UserID
            };
            var ViewModel = await Mediator.Send(query);
            return Ok(ViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteBodyViewModel>> Get(Guid id)
        {
            GetNoteBodyQuery query = new GetNoteBodyQuery
            {
                userID = UserID,
                ID = id
            };
            var ViewModel = await Mediator.Send(query);
            return Ok(ViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDTO createNoteDTO)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDTO);
            command.userID = UserID;
            var noteID = await Mediator.Send(command);
            return Ok(noteID);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateNoteDTO updateNoteDTO)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDTO);
            command.userID = UserID;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                ID = id,
                userID = UserID
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

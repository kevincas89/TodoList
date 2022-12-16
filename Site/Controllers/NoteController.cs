using BLL.Base;
using DAL;
using DAL.Interface;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Site.Models;
using System.Text.RegularExpressions;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;


        public NoteController(TodoListContext todoListContext, IUnitOfWork unitOf)
        {
            _noteService = new NoteService(todoListContext, unitOf);
        }

        [HttpPost("Insertar")]
        public async Task<ActionResult<Note>> Insert(NoteDTO note)
        {

            var request = await _noteService.Insert(Mapping(note), note.ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }


        [HttpGet("ConsultarLista")]
        public async Task<ActionResult<Note>> GetAll()
        {
            var request = await _noteService.GetAll();
            return request.Error ? Problem(request.Message) : Ok(request.Entities);
        }


        [HttpGet("ConsultarId/{Cod_Marca}")]
        public async Task<ActionResult<Note>> GetById(int ID)
        {
            var request = await _noteService.GetById(ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }


        [HttpPut("Actualicar/{Cod_Marca}")]
        public async Task<ActionResult<Note>> Update(int ID, NoteDTO note)
        {
            var request = await _noteService.Update(Mapping(note), note.ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }


        [HttpDelete("Eliminar/{Cod_Marca}")]
        public async Task<ActionResult<Note>> Delete(int ID)
        {
            var request = await _noteService.Delete(ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }


        private Note Mapping(NoteDTO noteDto)
        {
            var note = new Note();
            note.ID = noteDto.ID;
            note.Title = noteDto.Title;
            note.Description = noteDto.Description;
            note.State = noteDto.State;
            note.User = noteDto.User;
            return note;
        }
    }
}

using Abp.Domain.Uow;
using BLL.Base;
using BLL.Interface;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(TodoListContext todoListContext, IUnitOfWork unitOf)
        {
            _userService = new UserService(todoListContext, unitOf);
        }


        [HttpPost("Insertar")]
        public async Task<ActionResult<User>> Insert(UserDTO user)
        {

            var request = await _userService.Insert(Mapping(user), user.ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }


        [HttpGet("ConsultarLista")]
        public async Task<ActionResult<User>> GetAll()
        {
            var request = await _userService.GetAll();
            return request.Error ? Problem(request.Message) : Ok(request.Entities);
        }



        [HttpGet("ConsultarId/{Cod_Marca}")]
        public async Task<ActionResult<User>> GetById(int ID)
        {
            var request = await _userService.GetById(ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }



        [HttpPut("Actualicar/{Cod_Marca}")]
        public async Task<ActionResult<User>> Update(int ID, UserDTO user)
        {
            var request = await _userService.Update(Mapping(user), user.ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }


        [HttpDelete("Eliminar/{Cod_Marca}")]
        public async Task<ActionResult<User>> Delete(int ID)
        {
            var request = await _userService.Delete(ID);
            return request.Error ? Problem(request.Message) : Ok(request.Entity);
        }

        private User Mapping(UserDTO userDto)
        {
            var user = new User();
            user.ID = userDto.ID;   
            user.Username = userDto.Username;
            user.Password = userDto.Password;
            user.State = userDto.State;
            user.Role = userDto.Role;
            return user;
        }




    }
}

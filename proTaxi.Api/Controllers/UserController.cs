using Microsoft.AspNetCore.Mvc;
using proTaxi.Api.Models.Role;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Models.Usuarios;
using proTaxi.Persistence.Repositories;
using proTaxi.Domain.Entities;
using proTaxi.Api.Models.Usuario;



namespace proTaxi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioRepository userRepository;
        public UserController(IUsuarioRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {
            List<Usuario> result = new List<Usuario>();

            result = await this.userRepository.GetAll();

            if (result.Count > 0)
            {
                return Ok(result);

            }

            return BadRequest("Invalid_Null_Or_Empty");
        }


        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            DataResult<Usuario> result = new DataResult<Usuario>();

            result = await this.userRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }


        [HttpPost("SaveUser")]
        public async Task<IActionResult> Post([FromBody] UserAddDto userAddDto)
        {
            bool result = false;
            result = await this.userRepository.Save(new Domain.Entities.Usuario()
            {
                Nombre = userAddDto.Nombre,
                Apellido = userAddDto.Apellido,
                Documento = userAddDto.Documento,

            });
            if (!result)
            {
                return BadRequest();

            }
            return Ok();
        }


        [HttpPost("UpdateUser")]
        public async Task<IActionResult> Put([FromBody] UserUpdateDto userUpdateDto)
        {
            bool result = false;
            result = await this.userRepository.Update(new Domain.Entities.Usuario()
            {
                Id = userUpdateDto.Id,
                Nombre = userUpdateDto.Nombre,
                Apellido = userUpdateDto.Apellido,
                Documento = userUpdateDto.Documento,
            });
            if (!result)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }


    }
}

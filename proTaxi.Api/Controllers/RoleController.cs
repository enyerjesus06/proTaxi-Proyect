using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using proTaxi.Api.Models.Role;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Models.Role;
using System.Collections.Generic;
using proTaxi.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proTaxi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> Get()
        {
            DataResult<List<RoleModel>> result = new DataResult<List<RoleModel>>();

            result = await this.roleRepository.GetRoles();

            if (!result.Success)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }

        
        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole(int id)
        {
            DataResult<RoleModel> result = new DataResult<RoleModel>();

            result = await this.roleRepository.GetRole(id);

            if (!result.Success)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }

       
        [HttpPost("SaveRole")]
        public async Task<IActionResult> Post([FromBody] RoleAddDto roleAddDto)
        {
            bool result = false;
            result = await this.roleRepository.Save(new Domain.Entities.Role()
            { 
             Nombre = roleAddDto.Nombre,
             
              
            });
            if (!result) 
            {
                return BadRequest();
            
            }
            return Ok();
        }

       
        [HttpPost("UpdateRole")]
        public async Task<IActionResult> Put([FromBody] RoleUpdateDto roleUpdateDto)
        {
            bool result = false;
            result = await this.roleRepository.Update(new Domain.Entities.Role()
            {
                Id = roleUpdateDto.Id,
                Nombre = roleUpdateDto.Nombre,
            });
            if (!result)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        
    }
}

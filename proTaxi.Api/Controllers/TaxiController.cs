using Microsoft.AspNetCore.Mvc;
using proTaxi.Api.Models.Role;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Models.Taxi;
using proTaxi.Domain.Entities;
using proTaxi.Api.Models.TaxiDto;



namespace proTaxi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        protected readonly ITaxiRepository taxiRepository;
        public TaxiController(ITaxiRepository taxiRepository)
        {
            this.taxiRepository = taxiRepository;
        }

        [HttpGet("GetTaxis")]
        public async Task<IActionResult> Get()
        {
            
            List<Taxi> result = new List<Taxi>();

            result = await this.taxiRepository.GetAll();

            if (result.Count > 0)
            {
                return Ok(result);

            }

            return BadRequest("Invalid_Null_Or_Empty");
        }


        [HttpGet("GetTaxi")]
        public async Task<IActionResult> GetEntityBy(int id)
        {
            DataResult<Taxi> result = new DataResult<Taxi>();

            result = await this.taxiRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }


        [HttpPost("SaveTaxi")]
        public async Task<IActionResult> Post([FromBody] TaxiAddDto taxiAddDto)
        {
            bool result = false;
            result = await this.taxiRepository.Save(new Domain.Entities.Taxi()
            {
                Placa = taxiAddDto.Placa,
                
            });
            if (!result)
            {
                return BadRequest();

            }
            return Ok();
        }


        [HttpPost("UpdateTaxi")]
        public async Task<IActionResult> Put([FromBody] TaxiUpdateDto taxiUpdateDto)
        {
            bool result = false;
            result = await this.taxiRepository.Update(new Domain.Entities.Taxi()
            {
                Id = taxiUpdateDto.Id,
                Placa = taxiUpdateDto.Placa,
            });
            if (!result)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

    }
}

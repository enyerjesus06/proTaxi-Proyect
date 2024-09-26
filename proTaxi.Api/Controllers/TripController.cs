using Microsoft.AspNetCore.Mvc;
using proTaxi.Api.Models.TaxiDto;
using proTaxi.Domain.Entities;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Models.Trips;
using proTaxi.Api.Models.Trip;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proTaxi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        protected readonly ITripRepository tripRepository;
        public TripController(ITripRepository tripRepository)
        {
            this.tripRepository = tripRepository;
        }

        [HttpGet("GetTrips")]
        public async Task<IActionResult> Get()
        {

            List<Trip> result = new List<Trip>();

            result = await this.tripRepository.GetAll();

            if (result.Count > 0)
            {
                return Ok(result);

            }

            return BadRequest("Invalid_Null_Or_Empty");
        }


        [HttpGet("GetTrip")]
        public async Task<IActionResult> GetEntityBy(int id)
        {
            DataResult<Trip> result = new DataResult<Trip>();

            result = await this.tripRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);

            }

            return Ok(result);
        }


        [HttpPost("SaveTrip")]
        public async Task<IActionResult> Post([FromBody] TripAddDto tripAddDto)
        {
            bool result = false;
            result = await this.tripRepository.Save(new Domain.Entities.Trip()
            {
                
                FechaInicio = tripAddDto.FechaInicio,
                FechaFin = tripAddDto.FechaFin,
                Desde = tripAddDto.Desde,
                Hasta = tripAddDto.Hasta,
                TaxiId = tripAddDto.TaxiId,
                UsuarioId = tripAddDto.UsuarioId,
                Calificacion = tripAddDto.Calificacion,



            });
            if (!result)
            {
                return BadRequest();

            }
            return Ok();
        }


        [HttpPost("UpdateTrip")]
        public async Task<IActionResult> Post([FromBody] TripUpdateDto tripUpdateDto)
        {
            bool result = false;
            result = await this.tripRepository.Update(new Domain.Entities.Trip()
            {

                Id = tripUpdateDto.Id,
                FechaInicio = tripUpdateDto.FechaInicio,
                FechaFin = tripUpdateDto.FechaFin,
                Desde = tripUpdateDto.Desde,
                 Hasta = tripUpdateDto.Hasta,
                 TaxiId = tripUpdateDto.TaxiId,
                 UsuarioId = tripUpdateDto.UsuarioId,
                 Calificacion = tripUpdateDto.Calificacion,


              
                
            });
            if (!result)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

    }
}


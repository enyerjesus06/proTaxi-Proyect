using System.ComponentModel.DataAnnotations;

namespace proTaxi.Api.Models.Trip
{
    public record TripUpdateDto : BaseTripDto
    {
        public int Id { get; set; }
      
    }
}

using proTaxi.Domain.Entities;

namespace proTaxi.Api.Models.TaxiDto
{
    public record TaxiAddDto
    {
        public required string Placa { get; set; }

        //public ICollection<Trip>? Trips { get; set; }
    }
}

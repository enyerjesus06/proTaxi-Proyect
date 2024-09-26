using proTaxi.Domain.Entities;

namespace proTaxi.Api.Models.TaxiDto
{
    public record TaxiUpdateDto
    {
        public int Id { get; set; }
        public required string Placa { get; set; }
        //public ICollection<Trip>? Trips { get; set; }
    }
}

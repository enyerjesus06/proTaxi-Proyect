using proTaxi.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace proTaxi.Api.Models.Trip
{
    public abstract record BaseTripDto
    {
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [StringLength(100)]
        public string? Desde { get; set; }

        [StringLength(100)]
        public string? Hasta { get; set; }

        public int? Calificacion { get; set; }
        public int TaxiId { get; set; }
       
        public int UsuarioId { get; set; }


    }
}

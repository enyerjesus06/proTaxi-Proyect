using proTaxi.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proTaxi.Domain.Entities
{
    [Table("Trip")]
    public sealed class Trip : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [StringLength(100)]
        public string? Desde { get; set; }

        [StringLength(100)]
        public string? Hasta { get; set; }

        public int? Calificacion { get; set; }

        [ForeignKey("TaxiId")]
        public int TaxiId { get; set; }

        public Taxi? Taxi { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public ICollection<TripDetails>? TripDetails { get; set; }
    }
}

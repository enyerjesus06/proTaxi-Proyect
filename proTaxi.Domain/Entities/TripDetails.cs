using proTaxi.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Domain.Entities
{
    [Table("TripDetails")]
    public sealed class TripDetails : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public float Latitud { get; set; }

        public float Longitud { get; set; }

        [ForeignKey("TripId")]
        public int TripId { get; set; }

        public Trip? Trip { get; set; }
    }
}

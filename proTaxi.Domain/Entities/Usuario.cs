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

    public sealed class Usuario : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Documento { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public required string Apellido { get; set; }

        
    }
}

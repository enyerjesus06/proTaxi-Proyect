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
    [Table("Role")]
    public sealed class Role : BaseEntity<int>
    {
        [Required]

        public override int Id { get; set; }

        [StringLength(50)]
        public required string Nombre { get; set; }

        public UserRole? UserRoles { get; set; }
    }
}

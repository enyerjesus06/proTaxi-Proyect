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
    [Table("UserGroup")]
    public sealed class UserGroup : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        public ICollection<UserGroupDetails>? UserGroupDetails { get; set; }
    }
}

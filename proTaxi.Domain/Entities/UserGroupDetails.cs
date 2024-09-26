using proTaxi.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Domain.Entities
{
    [Table("UserGroupDetails")]
    public sealed class UserGroupDetails : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        [ForeignKey("GrupoId")]
        public int GrupoId { get; set; }

        public UserGroup? UserGroup { get; set; }
    }
}

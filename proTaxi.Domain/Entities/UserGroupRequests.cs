using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using proTaxi.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace proTaxi.Domain.Entities
{
    [Table("UserGroupRequests")]
    public sealed class UserGroupRequests : BaseEntity<int>
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

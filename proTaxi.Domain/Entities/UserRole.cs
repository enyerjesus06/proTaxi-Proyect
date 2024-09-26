using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proTaxi.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace proTaxi.Domain.Entities
{
    [Table("UserRole")]

    [PrimaryKey(nameof(UsuarioId), nameof(RoleId))]
    public sealed class UserRole

    {
        public int UsuarioId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}

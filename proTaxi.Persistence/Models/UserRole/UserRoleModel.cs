using proTaxi.Persistence.Models.Role;
using proTaxi.Persistence.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Models.UserRole
{
    public class UserRoleModel
    {
        public int UsuarioId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioModel? Usuario { get; set; }

        [ForeignKey("RoleId")]
        public RoleModel? Role { get; set; }
    }
}

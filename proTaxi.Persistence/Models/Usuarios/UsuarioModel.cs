using proTaxi.Persistence.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Models.Usuarios
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Documento { get; set; }
        public ICollection<UserRoleModel>? UserRoles { get; set; }
    }
}

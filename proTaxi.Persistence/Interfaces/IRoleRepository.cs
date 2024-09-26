using proTaxi.Domain.Entities;
using proTaxi.Domain.Interfaces;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Models.Role;
using proTaxi.Persistence.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Interfaces
{
     public interface IRoleRepository : IRepository<Role, int>
     {
        Task<DataResult<RoleModel>> GetRole(int id);
        Task<DataResult<List<RoleModel>>> GetRoles();

    }
}

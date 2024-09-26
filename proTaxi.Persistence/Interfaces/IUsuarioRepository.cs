using proTaxi.Domain.Entities;
using proTaxi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Models.Usuarios;

namespace proTaxi.Persistence.Interfaces
{
     public interface IUsuarioRepository : IRepository<Usuario, int>
     {
        Task<bool> CreateAsync(UsuarioModel usuarioModel);
     }
}

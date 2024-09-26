using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Models.Usuarios;
using Microsoft.EntityFrameworkCore;
using proTaxi.Persistence.Repository;
using proTaxi.Domain.Entities;
using proTaxi.Persistence.Context;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using proTaxi.Persistence.Interfaces;

namespace proTaxi.Persistence.Repositories
{
    public sealed class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(Taxi_Db dbContext,
            ILogger<BaseRepository<Usuario, int>> logger,
            IConfiguration configuration)
            : base(dbContext, logger, configuration)
        {
        }

        #region Métodos Sobrescritos

        protected override bool ValidateSave(Usuario entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Nombre) || entity.Nombre.Length > 50)
            {
                _logger.LogWarning(this.configuration["User:Invalid_procedure"]);
                return false;
            }
            if (entity.Documento.Length > 50)
            {
                _logger.LogWarning(this.configuration["User:Invalid_procedure"]);
                return false;
            }
            return true;
        }

        protected override bool ValidateUpdate(Usuario entity)
        {
            if (entity.Id <= 0)
            {
                _logger.LogWarning(this.configuration["Role:Invalid_ID"]);
                return false;
            }
            return true;
        }

        public override async Task<bool> Remove(Usuario entity)
        {
            try
            {
                return await base.Remove(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.configuration["User:Error_While_removing"]);
                throw;
            }
        }

        public override async Task<List<Usuario>> GetAll()
        {
            var usuarios = await _dbSet.ToListAsync();
            return MapToUsuarioList(usuarios);
        }

        #endregion

        #region Métodos Públicos

        public async Task<bool> CreateAsync(UsuarioModel usuarioModel)
        {
            // Convertir UsuarioModel a la entidad Usuario
            var usuario = MapToUsuario(usuarioModel);

            await _dbSet.AddAsync(usuario);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        #endregion

        #region Métodos de Mapeo

        private List<Usuario> MapToUsuarioList(List<Usuario> usuarios)
        {
            return usuarios.Select(u => new Usuario
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Documento = u.Documento
            }).ToList();
        }

        private Usuario MapToUsuario(UsuarioModel usuarioModel)
        {
            return new Usuario
            {
                Nombre = usuarioModel.Nombre,
                Apellido = usuarioModel.Apellido,
                Documento = usuarioModel.Documento
            };
        }

        #endregion
    }
}
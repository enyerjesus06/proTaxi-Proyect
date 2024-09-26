using proTaxi.Persistence.Context;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Repository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using proTaxi.Persistence.Models.Role;
using proTaxi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using proTaxi.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace proTaxi.Persistence.Repositories
{
    public sealed class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(Taxi_Db taxi_Db, 
               ILogger<RoleRepository> logger, 
               IConfiguration configuration) 
               : base(taxi_Db, logger, configuration)
        {
        }

        #region Métodos Públicos

        // Implementación de GetRole por Id
        public async Task<DataResult<RoleModel>> GetRole(int id)
        {
            try
            {
                var role = await _dbSet
                    .Where(r => r.Id == id)
                    .Select(r => new RoleModel
                    {
                        Id = r.Id,
                        Nombre = r.Nombre
                    })
                    .FirstOrDefaultAsync();

                return role != null
                    ? new DataResult<RoleModel> { Result = role }
                    : CreateErrorResult<RoleModel>("Role:Does_Not_Exist");
            }
            catch (Exception)
            {
                return CreateErrorResult<RoleModel>("Role:Unspected_Error");
            }
        }

        // Implementación de GetRoles (devuelve todos los roles)
        public async Task<DataResult<List<RoleModel>>> GetRoles()
        {
            try
            {
                var roles = await _dbSet
                    .Select(r => new RoleModel
                    {
                        Id = r.Id,
                        Nombre = r.Nombre
                    })
                    .ToListAsync();

                return roles != null && roles.Any()
                    ? new DataResult<List<RoleModel>> { Result = roles }
                    : CreateErrorResult<List<RoleModel>>("Role:Does_Not_Exist");
            }
            catch (Exception)
            {
                return CreateErrorResult<List<RoleModel>>("Role:Unspected_Error");
            }
        }

        #endregion

        #region Métodos de Validación

        protected override bool ValidateSave(Role entity)
        {
            if (!IsValidRoleName(entity.Nombre, out string errorMessage))
            {
                _logger.LogError(errorMessage);
                return false;
            }

            if (IsRoleNameDuplicate(entity))
            {
                _logger.LogWarning(this.configuration["Role:Nombre_AlreadyExists"]);
                return false;
            }
            return true;
        }

        protected override bool ValidateUpdate(Role entity)
        {
            if (entity.Id <= 0 || string.IsNullOrWhiteSpace(entity.Nombre))
            {
                _logger.LogWarning(this.configuration["Role:Invalid_ID"]);
                return false;
            }

            if (_dbSet.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id) == null)
            {
                _logger.LogWarning(this.configuration["Role:Does_Not_Exist"]);
                return false;
            }

            if (IsRoleNameDuplicate(entity))
            {
                _logger.LogWarning(this.configuration["Role:Nombre_AlreadyExists"]);
                return false;
            }
            return true;
        }

        protected override bool ValidateRemove(Role entity)
        {
            if (_dbSet.Find(entity.Id) == null)
            {
                _logger.LogWarning(this.configuration["Role:Does_Not_Exist"]);
                return false;
            }
            return true;
        }

        #endregion

        #region Métodos Privados

        private bool IsValidRoleName(string roleName, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(roleName) || roleName.Length > 50)
            {
                errorMessage = this.configuration["Role:Nombre_null_or_TooLong"];
                return false;
            }
            errorMessage = null;
            return true;
        }

        private bool IsRoleNameDuplicate(Role entity)
        {
            return _dbSet.Any(r => r.Nombre == entity.Nombre && r.Id != entity.Id);
        }

        private DataResult<T> CreateErrorResult<T>(string configKey)
        {
            return new DataResult<T>
            {
                Success = false,
                Message = this.configuration[configKey]
            };
        }

        #endregion
    }
}
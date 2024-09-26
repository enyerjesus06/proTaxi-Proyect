using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proTaxi.Domain.Interfaces;
using proTaxi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using proTaxi.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace proTaxi.Persistence.Repository
{
    public abstract class BaseRepository<TEntity, TType> : IRepository<TEntity, TType> where TEntity : class
    {
        protected readonly Taxi_Db _dbContext;
        protected readonly ILogger<BaseRepository<TEntity, TType>> _logger;
        protected readonly IConfiguration configuration;
        protected DbSet<TEntity> _dbSet => _dbContext.Set<TEntity>();

        public BaseRepository(Taxi_Db dbContext, ILogger<BaseRepository<TEntity, TType>> logger, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _logger = logger;
            this.configuration = configuration;
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return await _dbSet.AnyAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking existence.");
                return false;
            }
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all entities.");
                return new List<TEntity>();
            }
        }

        public virtual async Task<DataResult<TEntity>> GetEntityBy(TType Id)
        {
            try
            {
                // Buscar la entidad por su Id
                var entity = await _dbSet.FindAsync(Id);

                // Validar si la entidad fue encontrada
                if (entity == null)
                {
                    return new DataResult<TEntity>
                    {
                        Success = false,
                        Message = "Entity not found.",
                        Result = null // Aunque sea null, indicamos el éxito/falla con Success.
                    };
                }

                // Si se encontró la entidad, devolvemos el resultado exitoso
                return new DataResult<TEntity>
                {
                    Success = true,
                    Result = entity
                };
            }
            catch (Exception ex)
            {
                // Registrar el error y devolver el resultado con el mensaje de error
                _logger.LogError(ex, "Error occurred while fetching entity by Id.");
                return new DataResult<TEntity>
                {
                    Success = false,
                    Message = "An error occurred while fetching the entity."
                };
            }
        }

        public virtual async Task<bool> Remove(TEntity entity)
        {
            try
            {
                if (!ValidateRemove(entity))
                {
                    return false;
                }

                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while removing entity of type {typeof(TEntity).Name}.");
                return false;
            }
        }

        public virtual async Task<bool> Save(TEntity entity)
        {
            try
            {
                if (!ValidateSave(entity))
                {
                    return false;
                }

                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while saving entity of type {typeof(TEntity).Name}.");
                return false;
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            try
            {
                if (!ValidateUpdate(entity))
                {
                    return false;
                }

                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating entity of type {typeof(TEntity).Name}.");
                return false;
            }
        }


        protected virtual bool ValidateSave(TEntity entity)
        {
            // Ejemplo de validaciones
            if (entity == null)
            {
                // La entidad no puede ser nula
                return false;
            }
            // Otras validaciones...

            // Si todas las validaciones pasan
            return true;
        }
        protected virtual bool ValidateUpdate(TEntity entity)
        {
            // Ejemplo de validaciones
            if (entity == null)
            {
                // La entidad no puede ser nula
                return false;
            }
            // Otras validaciones...

            // Si todas las validaciones pasan
            return true;
        }
        protected virtual bool ValidateRemove(TEntity entity)
        {
            // Ejemplo de validaciones
            if (entity == null)
            {
                // La entidad no puede ser nula
                return false;
            }

            // Si todas las validaciones pasan
            return true;
        }

    }
}

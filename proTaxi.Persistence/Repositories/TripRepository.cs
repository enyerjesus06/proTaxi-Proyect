using proTaxi.Domain.Entities;
using proTaxi.Persistence.Context;
using proTaxi.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proTaxi.Persistence.Repository;
using proTaxi.Persistence.Models.Trips;
using proTaxi.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace proTaxi.Persistence.Repositories
{
    public sealed class TripRepository : BaseRepository<Trip, int>, ITripRepository
    {
        public TripRepository(Taxi_Db dbContext,
            ILogger<BaseRepository<Trip, int>> logger,
            IConfiguration configuration) : base(dbContext, logger, configuration)
        {
        }

        #region Métodos Públicos

        public async Task<TripModel> GetTripDetails(int tripId)
        {
            try
            {
                var trip = await _dbSet
                    .Include(t => t.Taxi)
                    .Include(t => t.Usuario)
                    .Include(t => t.TripDetails)
                    .FirstOrDefaultAsync(t => t.Id == tripId);

                if (trip == null)
                {
                    _logger.LogWarning(this.configuration["Trip:trip_NotFound"]);
                    return new TripModel(); // Devuelve un objeto vacío o inicializado
                }

                return MapTripToModel(trip);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.configuration["Trip:Logger_Details_Trip"]);
                throw; // Re-lanzar la excepción
            }
        }

        public async Task<List<TripModel>> GetTripsByTaxiId(int taxiId)
        {
            try
            {
                var trips = await _dbSet
                    .Where(t => t.TaxiId == taxiId)
                    .Include(t => t.Taxi) // Unión con Taxi
                    .Include(t => t.Usuario) // Unión con Usuario
                    .Include(t => t.TripDetails) // Incluir detalles del viaje
                    .ToListAsync();

                return MapTripsToModels(trips);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.configuration["Trip:Logger_Error_trips"]);
                return new List<TripModel>(); // Devuelve una lista vacía en caso de error
            }
        }

        public async Task<List<TripModel>> GetTripsByUserId(int userId)
        {
            try
            {
                var trips = await _dbSet
                    .Where(t => t.UsuarioId == userId)
                    .Include(t => t.Taxi) // Unión con Taxi
                    .Include(t => t.Usuario) // Unión con Usuario
                    .Include(t => t.TripDetails) // Incluir detalles del viaje
                    .ToListAsync();

                return MapTripsToModels(trips);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.configuration["Trip:Logger_Error_trips"]);
                return new List<TripModel>(); // Devuelve una lista vacía en caso de error
            }
        }

        public override async Task<bool> Save(Trip entity)
        {
            try
            {
                if (!IsValidTripForSave(entity, out string saveErrorMessage))
                {
                    _logger.LogWarning(saveErrorMessage);
                    return false;
                }

                return await base.Save(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.configuration["Trip:Error_While_Saving"], entity.Id);
                return false;
            }
        }

        public override async Task<bool> Update(Trip entity)
        {
            try
            {
                if (!IsValidTripForUpdate(entity, out string updateErrorMessage))
                {
                    _logger.LogWarning(updateErrorMessage);
                    return false;
                }

                return await base.Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.configuration["Trip:Error_Updating"], entity.Id);
                return false;
            }
        }

        #endregion

        #region Métodos de Validación

        protected override bool ValidateRemove(Trip entity)
        {
            if (HasTripDetails(entity.Id))
            {
                _logger.LogWarning(this.configuration["Trip:Cannot_Remove"]);
                return false;
            }
            return true;
        }

        private bool IsValidTripForSave(Trip entity, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (entity.FechaInicio == default)
            {
                errorMessage = this.configuration["Trip:Cannot_Save_whitout_DateTime"];
                return false;
            }

         

            return true;
        }

        private bool IsValidTripForUpdate(Trip entity, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (entity.Id <= 0)
            {
                errorMessage = this.configuration["Role:Invalid_ID"];
                return false;
            }

            if (entity.FechaInicio == default)
            {
                errorMessage = this.configuration["Trip:Cannot_UpDate_whitout_DateTime"];
                return false;
            }

            return true;
        }

        private bool HasTripDetails(int tripId)
        {
            return _dbSet.Any(td => td.Id == tripId && td.TripDetails.Count != 0);
        }

        #endregion

        #region Métodos de Mapeo

        private TripModel MapTripToModel(Trip trip)
        {
            return new TripModel
            {
                Id = trip.Id,
                FechaInicio = trip.FechaInicio,
                FechaFin = trip.FechaFin,
                Desde = trip.Desde,
                Hasta = trip.Hasta,
                Calificacion = trip.Calificacion,
                // Añadir aquí el mapeo para otras propiedades si es necesario
            };
        }

        private List<TripModel> MapTripsToModels(List<Trip> trips)
        {
            return trips.Select(t => new TripModel
            {
                Id = t.Id,
                FechaInicio = t.FechaInicio,
                FechaFin = t.FechaFin,
                Desde = t.Desde,
                Hasta = t.Hasta,
                Calificacion = t.Calificacion,
                // Mapear otras propiedades necesarias del modelo
            }).ToList();
        }

       

        #endregion
    }
}
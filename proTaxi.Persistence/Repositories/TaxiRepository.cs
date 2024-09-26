using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proTaxi.Domain.Entities;
using proTaxi.Persistence.Context;
using proTaxi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proTaxi.Persistence.Repository;
using proTaxi.Persistence.Models.Taxi;
using Microsoft.Extensions.Configuration;
using proTaxi.Domain.Models;

namespace proTaxi.Persistence.Repositories
{
    public sealed class TaxiRepository : BaseRepository<Taxi, int>, ITaxiRepository
    {
        public TaxiRepository(Taxi_Db dbContext,
            ILogger<TaxiRepository> logger,
            IConfiguration configuration)
            : base(dbContext, logger, configuration)
        {
        }

        #region Métodos Públicos

        public override Task<DataResult<Taxi>> GetEntityBy(int Id)
        {
            return base.GetEntityBy(Id);
        }

        #endregion

        #region Métodos de Validación

        protected override bool ValidateSave(Taxi entity)
        {
            if (!IsValidTaxiPlaca(entity.Placa, out string errorMessage))
            {
                _logger.LogWarning(errorMessage);
                return false;
            }
            return true;
        }

        protected override bool ValidateUpdate(Taxi entity)
        {
            string errorUpdateMessage = string.Empty;
            if (!IsValidTaxiId(entity.Id) || !IsValidTaxiPlaca(entity.Placa, out _))
            {
                _logger.LogWarning(errorUpdateMessage);
                return false;
            }
            return true;
        }

        protected override bool ValidateRemove(Taxi entity)
        {
            if (IsTaxiInUse(entity.Id))
            {
                _logger.LogWarning(this.configuration["Taxi:Cannot_Remove"]);
                return false;
            }
            return true;
        }

        #endregion

        #region Métodos Privados

        private bool IsValidTaxiPlaca(string placa, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                errorMessage = this.configuration["Taxi:Invalid_Null_Or_Empty"];
                return false;
            }
            errorMessage = null;
            return true;
        }

        private bool IsValidTaxiId(int id)
        {
            return id > 0;
        }

        private bool IsTaxiInUse(int taxiId)
        {
            var taxiWithTrips = _dbSet
                .Include(t => t.Trips)
                .FirstOrDefault(t => t.Id == taxiId);

            return taxiWithTrips != null && taxiWithTrips.Trips.Any(trip => trip.FechaFin == null);
        }

        #endregion
    }
}
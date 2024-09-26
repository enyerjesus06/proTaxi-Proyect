using proTaxi.Domain.Entities;
using proTaxi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proTaxi.Domain.Models;
using proTaxi.Persistence.Models.Trips;

namespace proTaxi.Persistence.Interfaces
{
    public interface ITripRepository : IRepository<Trip, int>
    {

        // Obtener todos los viajes por usuario
        Task<List<TripModel>> GetTripsByUserId(int userId);

        // Obtener todos los viajes por taxi
        Task<List<TripModel>> GetTripsByTaxiId(int taxiId);


        // Obtener los detalles de un viaje específico
        Task<TripModel> GetTripDetails(int tripId);
    }
}
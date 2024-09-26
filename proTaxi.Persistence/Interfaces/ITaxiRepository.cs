using proTaxi.Domain.Entities;
using proTaxi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using proTaxi.Persistence.Models.Taxi;

namespace proTaxi.Persistence.Interfaces
{
    public interface ITaxiRepository : IRepository<Taxi, int>
    {
      
    }
}
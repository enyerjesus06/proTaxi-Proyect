using proTaxi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Models.Taxi
{
    public class TaxiModel
    {
        public int Id { get; set; }
        public string? Placa { get; set; }

        public ICollection<Trip>? Trips { get; set; }

    }
}

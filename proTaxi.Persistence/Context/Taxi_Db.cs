using Microsoft.EntityFrameworkCore;
using proTaxi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proTaxi.Persistence.Models.Trips;

namespace proTaxi.Persistence.Context
{
    public class Taxi_Db : DbContext
    {
        public Taxi_Db(DbContextOptions<Taxi_Db> options):base(options) 
        {
        
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Taxi> Taxis { get; set; }
        public DbSet<Trip>  Trips { get; set; }
        public DbSet<TripDetails> TripDetails  { get; set; }
        public DbSet<UserGroup> UserGroups   { get; set; }
        public DbSet<Usuario> Usuario   { get; set; }
        public DbSet<UserGroupDetails>  UserGroupDetails  { get; set; }
        public DbSet<UserGroupRequests> UserGroupRequests { get; set; }


    }
}

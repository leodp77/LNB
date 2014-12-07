using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using LNB.Models;

namespace LNB.DAL
{
    public class LnbContext: DbContext
    {
        public LnbContext():base("LnbContext") {}


        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        public DbSet<TeamPlay> TeamPlays { get; set;}
        public DbSet<PlayerPlay> PlayerPlays { get; set;}
        public DbSet<PlayerPlayType> PlayerPlayTypes { get; set;}
        public DbSet<TeamPlayType> TeamPlayType { get; set;}
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<TeamStatistic> TeamStatistics { get; set; }
        public DbSet<CoachStatistic> CoachStatistics { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CoachTeamRelationship> CoachTeamRelationships { get; set; }
        public DbSet<PlayerTeamRelationship> PlayerTeamRelationships { get; set; }
        //public DbSet<Province> Provinces { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Tournament> Tournaments { get; set; }
        
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrepaidSystemContext.Entity;
using PrepaidSystemContext.StoredProcedures;

namespace PrepaidSystemContext
{
    public class PrepaidSystemContext : DbContext
    {
        public PrepaidSystemContext()
        {
        }

        public PrepaidSystemContext(DbContextOptions<PrepaidSystemContext> options)
            : base(options)
        { }

        public DbSet<Card> Card { get; set; }

        public DbSet<CardUse> CardUse { get; set; }

        public DbSet<DayOnRoute> DayOnRoute { get; set; }

        public DbSet<DayProfile> DayProfile { get; set; }

        public DbSet<Departure> Departure { get; set; }

        public DbSet<Line> Line { get; set; }

        public DbSet<Log> Log { get; set; }

        public DbSet<Passenger> Passenger { get; set; }

        public DbSet<Route> Route { get; set; }

        public DbSet<Stop> Stop { get; set; }

        public DbSet<StopOnRoute> StopOnRoute { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todo: may be moved somewhere else to not clutter up this class

            modelBuilder.Entity<BusCourse>(busCourseBuilder =>
            {
                busCourseBuilder.HasKey(bc => bc.Id);
                busCourseBuilder.HasOne(bc => bc.Route).WithMany();
            });

            modelBuilder.Entity<Card>(cardBuilder =>
            {
                cardBuilder.HasKey(c => c.Id);
                cardBuilder.HasOne(c => c.Passenger).WithMany(p => p.Cards);
            });

            modelBuilder.Entity<CardUse>(cardUseBuilder =>
            {
                cardUseBuilder.HasKey(cu => cu.Id);
                cardUseBuilder.HasOne(cu => cu.Stop).WithMany();
                cardUseBuilder.HasOne(cu => cu.Card).WithMany();
                cardUseBuilder.HasOne(cu => cu.BusCourse).WithMany();
                cardUseBuilder.HasOne(cu => cu.Transaction).WithMany();
            });

            modelBuilder.Entity<DayOnRoute>(dayOnRouteBuilder =>
            {
                dayOnRouteBuilder.HasKey(dor => dor.DateTime);
                dayOnRouteBuilder.HasOne(dor => dor.Route).WithMany(r => r.DaysOnRoute);
                dayOnRouteBuilder.HasOne(dor => dor.DayProfile).WithMany();
            });

            modelBuilder.Entity<DayProfile>(dayProfileBuilder =>
            {
                dayProfileBuilder.HasKey(dp => dp.Id);
            });

            modelBuilder.Entity<Departure>(departureBuilder =>
            {
                departureBuilder.HasKey(d => d.Id);
                departureBuilder.HasOne(d => d.DayProfile).WithMany(dp => dp.Departures);
            });

            modelBuilder.Entity<Line>(lineBuilder =>
            {
                lineBuilder.HasKey(l => l.Id);
            });

            modelBuilder.Entity<Log>(logBuilder =>
            {
                logBuilder.HasKey(l => l.Id);
            });

            modelBuilder.Entity<Passenger>(passengerBuilder =>
            {
                passengerBuilder.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Route>(routeBuilder =>
            {
                routeBuilder.HasKey(r => r.Id);
                routeBuilder.HasOne(r => r.Line).WithMany(l => l.Routes);
            });

            modelBuilder.Entity<Stop>(stopBuilder =>
            {
                stopBuilder.HasKey(s => s.Id);
            });

            modelBuilder.Entity<StopOnRoute>(stopOnRouteBuilder =>
            {
                stopOnRouteBuilder.HasKey(sor => new { sor.RouteId, sor.StopId });
                stopOnRouteBuilder.HasOne(sor => sor.Route).WithMany(r => r.StopsOnRoute);
                stopOnRouteBuilder.HasOne(sor => sor.Stop).WithMany(s => s.StopsOnRoute);
            });

            modelBuilder.Entity<Transaction>(transactionBuilder =>
            {
                transactionBuilder.HasKey(t => t.Id);
                transactionBuilder.HasOne(t => t.Passenger).WithMany(p => p.Transactions);
                transactionBuilder.HasOne(t => t.User).WithMany(u => u.Transactions);
                transactionBuilder.Property(t => t.TransactionType).HasColumnName("TypeId");
            });

            modelBuilder.Entity<User>(userBuilder =>
            {
                userBuilder.HasKey(u => u.Id);
                userBuilder.Property(u => u.Role).HasColumnName("RoleId");
            });
        }

        public decimal GetBalanceChangeInPeriod(DateTime startDate, DateTime endDate)
        {
            return new GetBalanceChangeInPeriodStoredProcedure(startDate, endDate)
                .ExecuteAndRead(this.Database.GetDbConnection());
        }

        public decimal GetBalanceChange()
        {
            return new GetBalanceChangeStoredProcedure()
                 .ExecuteAndRead(this.Database.GetDbConnection());
        }

        public int GetUserTypes(int roleTypeId)
        {
            return new GetUserTypesStoredProcedure(roleTypeId)
                .ExecuteAndRead(this.Database.GetDbConnection());
        }

        public int GetNumberOfRidesInPeriod(int lineId, DateTime startDate, DateTime endDate)
        {
            return new GetNumberOfRidesInPeriodStoredProcedure(lineId, startDate, endDate)
                .ExecuteAndRead(this.Database.GetDbConnection());
        }

        public int GetNumberOfRides(int lineId)
        {
            return new GetNumberOfRidesStoredProcedure(lineId)
                .ExecuteAndRead(this.Database.GetDbConnection());
        }

        public int GetNumberOfPassengersInPeriod(DateTime startDate, DateTime endDate)
        {
            return new GetNumberOfPassengersInPeriodStoredProcedure(startDate, endDate)
                .ExecuteAndRead(this.Database.GetDbConnection());
        }

        public int GetNumberOfPassengers()
        {
            return new GetNumberOfPassengersStoredProcedure()
                .ExecuteAndRead(this.Database.GetDbConnection());
        }
    }
}

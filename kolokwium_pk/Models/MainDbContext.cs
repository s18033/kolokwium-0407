using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_pk.Models
{
    public class MainDbContext : DbContext
    {
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Firetruck> Firetrucks { get; set; }
        public DbSet<FiretruckAction> FiretruckActions { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firefighter>().HasKey(c => new { c.IdFirefighter });
            modelBuilder.Entity<Action>().HasKey(c => new { c.IdAction });
            modelBuilder.Entity<Firetruck>().HasKey(c => new { c.IdFiretruck});
            modelBuilder.Entity<FirefighterAction>().HasKey(c => new { c.IdFirefighter, c.IdAction });
            modelBuilder.Entity<FiretruckAction>().HasKey(c => new { c.IdFiretruck, c.IdAction });

            modelBuilder.Entity<Firefighter>().HasData(new Firefighter
            {
                FirstName = "Piotr",
                LastName = "Kwiatek",
                IdFirefighter = 1
            });

            modelBuilder.Entity<Action>().HasData(new Action
            {
                IdAction = 3,
                StartTime = DateTime.Now,
                NeedSpecialEquipment = false
            });

            modelBuilder.Entity<Action>().HasData(new Action
            {
                IdAction = 4,
                StartTime = DateTime.Now,
                NeedSpecialEquipment = false
            });

            modelBuilder.Entity<Action>().HasData(new Action
            {
                IdAction = 5,
                StartTime = DateTime.Now,
                NeedSpecialEquipment = true
            });

            modelBuilder.Entity<FirefighterAction>().HasData(new FirefighterAction
            {
                IdAction = 3,
                IdFirefighter = 1
            });

            modelBuilder.Entity<FirefighterAction>().HasData(new FirefighterAction
            {
                IdAction = 4,
                IdFirefighter = 1
            });

            modelBuilder.Entity<FirefighterAction>().HasData(new FirefighterAction
            {
                IdAction = 5,
                IdFirefighter = 1
            });

            modelBuilder.Entity<Firetruck>().HasData(new Firetruck
            {
                IdFiretruck = 1,
                OperationalNumber = "ABC1111",
                SpecialEquipment = true
            });

            modelBuilder.Entity<Firetruck>().HasData(new Firetruck
            {
                IdFiretruck = 2,
                OperationalNumber = "XXX1111",
                SpecialEquipment = false
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Data
{
    public class KitchenContext : DbContext
    {
        public KitchenContext (DbContextOptions<KitchenContext> options)
            : base(options)
        {
        }

        public DbSet<ChefsAndDishes.Models.Chef> Chefs { get; set; }

        public DbSet<ChefsAndDishes.Models.Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<Chef>().ToTable("Chef");
            modelBuilder.Entity<Chef>().HasMany<Dish>(thing => thing.Dishes);
            

        }
    }
}

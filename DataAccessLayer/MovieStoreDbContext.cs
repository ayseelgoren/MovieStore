using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MovieStoreDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MoviePlayer> MoviePlayer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=MovieStore");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviePlayer>().HasKey(MP => new { MP.PlayersId, MP.MoviesId });

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, GenreName = "Korku" },
                new Genre { Id = 2, GenreName = "Gerilim" },
                new Genre { Id = 3, GenreName = "Fantastik" }
            );
        }
    }
}

using DataAccess.Entities;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using DataAccess.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess
{
    public class CinemaContext : IdentityDbContext<User>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> MovieGenres {  get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public CinemaContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CinemaDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new GenreMovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaHallConfiguration());

            modelBuilder.SeedGenreList();
            modelBuilder.SeedMovieList();
        }

    }
}

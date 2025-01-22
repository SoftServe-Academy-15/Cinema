using DataAccess.Entities;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CinemaContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> MovieGenres {  get; set; }
        public DbSet<Movie> Movies { get; set; }
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

            modelBuilder.Entity<GenreMovie>().HasKey(gm => new { gm.MovieId, gm.GenreId });
            modelBuilder.Entity<GenreMovie>()
                .HasOne<Genre>(gm => gm.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(gm => gm.GenreId);


            modelBuilder.Entity<GenreMovie>()
                .HasOne<Movie>(gm => gm.Movie)
                .WithMany(g => g.Genres)
                .HasForeignKey(gm => gm.MovieId);
            modelBuilder.SeedGenreList();
            modelBuilder.SeedMovieList();
        }

    }
}

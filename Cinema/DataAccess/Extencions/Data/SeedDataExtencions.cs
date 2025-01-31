using DataAccess.Entities.Enums;
using DataAccess.Entities.MovieInformation;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extencions.Data
{
    public static class SeedData
    {
        public static void SeedGenreList(this ModelBuilder modelBuilder)
        {
            GenresEnum[] genres = Enum.GetValues(typeof(GenresEnum)).Cast<GenresEnum>().ToArray();
            Genre[] genreList = new Genre[genres.Length];
            for (int i = 0; i < genres.Length; i++)
            {
                genreList[i] = new Genre() { Id = i + 1, GenreName = genres[i] };
            }
            modelBuilder.Entity<Genre>().HasData(genreList);
        }
        public static void SeedMovieList(this ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Movie>().HasData(new Movie[]
            //{
            //    new Movie() { Id = 1,
            //        Cast = "sdfg sdf",
            //        Description = "ds",
            //        Rating = 9,
            //        Title = "tl",
            //        TrailerLink = "https://www.youtube.com/watch?v=xqCNVGCPtJ8&ab_channel=MonolithGD",
            //        Genres = new List<GenreMovie>(new GenreMovie[] {
            //            new GenreMovie() { Genre = new Genre() { GenreName = GenresEnum.Action, Id = 1 } },
            //            new GenreMovie() { Genre = new Genre() { GenreName = GenresEnum.Mysteries, Id = 2 } }, })
            //    }
            //});
        }
    }
}

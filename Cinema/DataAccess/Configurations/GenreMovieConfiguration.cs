using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
	public class GenreMovieConfiguration : IEntityTypeConfiguration<GenreMovie>
	{
		public void Configure(EntityTypeBuilder<GenreMovie> builder)
		{
            builder.HasKey(gm => new { gm.MovieId, gm.GenreId });

            builder.HasOne<Genre>(gm => gm.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(gm => gm.GenreId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.HasOne<Movie>(gm => gm.Movie)
                .WithMany(g => g.Genres)
                .HasForeignKey(gm => gm.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

        }
	}
}
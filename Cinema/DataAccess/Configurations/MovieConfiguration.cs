using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Title).IsRequired();
            
            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.TrailerLink).IsRequired();

            builder.Property(x => x.Cast).IsRequired();

            builder.Property(x => x.Rating).HasDefaultValue<float>(0);

        }
    }
}

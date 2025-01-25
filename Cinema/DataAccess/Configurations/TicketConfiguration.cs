using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            // Foreign key
            builder.HasKey(t => t.Id);

            // Required field
            builder.Property(t => t.SessionId)
                .IsRequired();

            // Field SessionId: ForeignKey to Session
            builder.HasOne<Session>()
                .WithMany()
                .HasForeignKey(t => t.SessionId)
                .OnDelete(DeleteBehavior.Cascade); // Remove all related tickets when Session is deleted

            // Required field
            builder.Property(t => t.Price)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            // Required field
            builder.Property(t => t.PlaceRowNumber)
                .IsRequired();

            // Required field
            builder.Property(t => t.PlaceColumnNumber)
                .IsRequired();

            // Required field
            builder.Property(t => t.UserId)
                .IsRequired();

            // Field UserId: ForeignKey to User
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Remove all related tickets when User is deleted
        }
    }
}
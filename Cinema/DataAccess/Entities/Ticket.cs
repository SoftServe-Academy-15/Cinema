using DataAccess.Enteties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Ticket : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int PlaceRowNumber { get; set; }

        [Required]
        public int PlaceColumnNumber { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
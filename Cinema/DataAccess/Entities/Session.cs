using DataAccess.Enteties;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Session : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        [ForeignKey(nameof(Hall))]
        public int HallId { get; set; }
    }
}

using DataAccess.Enteties;

namespace DataAccess.Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public float Price { get; set; }

        public int PlaceRowNumber { get; set; }

        public int PlaceColumnNumber { get; set; }

        public User UserId { get; set; }
    }
}
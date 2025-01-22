using DataAccess.Enteties;

namespace DataAccess.Entities
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TrailerLink { get; set; }
        public string Cast { get; set; }
        public float Rating { get; set; }
        public List<GenreMovie> Genres { get; set; }
    }
}

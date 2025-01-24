using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Interfaces;

namespace DataAccess.Entities
{
    public enum GenresEnum
    {
        Undefined,
        Action,
        Thriller,
        Mysteries
    }
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string GenreNameString { get; private set; }

        [NotMapped]
        private GenresEnum _genreName;
        [NotMapped]
        public GenresEnum GenreName { get { return _genreName; } 
            set 
            { 
                GenreNameString = Enum.GetName(typeof(GenresEnum), value);
                _genreName = value;
            } 
        }
        public List<GenreMovie> Movies { get; set; }

    }
    public class GenreMovie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

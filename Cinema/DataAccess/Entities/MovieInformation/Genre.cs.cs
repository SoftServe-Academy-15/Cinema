using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Entities.Enums;
using DataAccess.Interfaces;

namespace DataAccess.Entities.MovieInformation
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string GenreNameString { get; private set; }

        [NotMapped]
        private GenresEnum _genreName;
        [NotMapped]
        public GenresEnum GenreName
        {
            get { return _genreName; }
            set
            {
                GenreNameString = Enum.GetName(typeof(GenresEnum), value);
                _genreName = value;
            }
        }
        public List<GenreMovie> Movies { get; set; }

    }
}

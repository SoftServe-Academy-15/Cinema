using Ardalis.Specification;
using DataAccess.Entities.MovieInformation;

namespace DataAccess.Entities.Specifications
{
    public class ActorSpecifications
    {
        public class ByIds : Specification<Actor>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Movies);
            }
        }
        public class ById : Specification<Actor>
        {
            public ById(int id)
            {
                Query
                    .Where(x => id == x.Id)
                    .Include(x => x.Movies);
            }
        }
        public class ByName : Specification<Actor>
        {
            public ByName(string name)
            {
                Query
                    .Where(x => (x.Name + " " + x.Surname).ToLower().Contains(name.ToLower()))
                    .Include(x => x.Movies);
            }
        }
        public class ByMovie : Specification<Actor>
        {
            public ByMovie(int movieId)
            {
                Query
                    .Where(x => x.Movies.Select(m => m.MovieId).Contains(movieId))
                    .Include(x => x.Movies);
            }
        }
    }
}

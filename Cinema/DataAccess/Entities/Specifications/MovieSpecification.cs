using Ardalis.Specification;
using DataAccess.Entities.MovieInformation;
using DataAccess.Extencions.EntityExtencions;

namespace DataAccess.Entities.Specifications
{
    public class MovieSpecification
    {
        public class All : Specification<Movie>
        { 
           public All()
            {
                Query
                    .Include(x => x.Genres).Include(x => x.Actors);
            }
        }
        public class ByIds : Specification<Movie>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Genres).Include(x => x.Actors);
            }
        }
        public class ById : Specification<Movie>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Genres).Include(x => x.Actors);
            }
        }
        public class ByGenres : Specification<Movie>
        {
            public ByGenres(List<string> genres)
            {
                Query.
                    Where(x => x.ContainsAllGenres(genres))
                    .Include(x => x.Genres).Include(x => x.Actors);
            }
        }
        public class ByActors : Specification<Movie>
        {
            public ByActors(List<int> actorIds)
            {
                Query.
                    Where(x => x.ContainsAllActors(actorIds))
                    .Include(x => x.Genres).Include(x => x.Actors);
            }
        }
    }
}

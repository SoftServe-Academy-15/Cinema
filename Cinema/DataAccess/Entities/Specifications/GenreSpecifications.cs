using Ardalis.Specification;
using DataAccess.Entities.MovieInformation;

namespace DataAccess.Entities.Specifications
{
    public class GenreSpecifications
    {
        public class ByIds : Specification<Genre>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Movies);
            }
        }
        public class ById : Specification<Genre>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Movies);
            }
        }
        public class ByName : Specification<Genre>
        {
            public ByName(string name)
            {
                Query.
                    Where(x => x.GenreName.ToLower().StartsWith(name.ToLower()))
                    .Include(x => x.Movies);
            }
        }
    }
}

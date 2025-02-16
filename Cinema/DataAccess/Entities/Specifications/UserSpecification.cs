using Ardalis.Specification;
using DataAccess.Entities.MovieInformation;
using DataAccess.Extencions.EntityExtencions;

namespace DataAccess.Entities.Specifications
{
    public class UserSpecification
    {
        public class All : Specification<User>
        { 
           public All()
            {
                Query
                    .Include(x => x.Id).Include(x => x.UserName).Include(x => x.IsAdmin);
            }
        }
        public class ByIds : Specification<User>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id));
            }
        }
        public class ById : Specification<User>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
        public class ByEmail : Specification<User>
        {
            public ByEmail(string email)
            {
                Query
                    .Where(x => x.Email == email);
            }
        }
        public class ByUserName : Specification<User>
        {
            public ByUserName(string userName)
            {
                Query
                    .Where(x => x.UserName == userName);
            }
        }
        //public class ByRole : Specification<User>
        //{
        //    public ByRole(bool[] role)
        //    {
        //        Query
        //            .Where(x => role.Contains(x.IsAdmin))
        //            .Select(x => new { x.Id, x.UserName, x.IsAdmin });
        //    }
        //}
    }
}

using DataAccess.Interfaces;

namespace DataAccess.Entities
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}

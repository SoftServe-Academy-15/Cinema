using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {
        public required Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}

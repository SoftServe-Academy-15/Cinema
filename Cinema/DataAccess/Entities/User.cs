using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {
        public required string UserId { get; set; }
        public bool Admin { get; set; }
    }
}

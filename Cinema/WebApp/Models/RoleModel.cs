using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace WebApp.Models
{
    public class RoleModel : PageModel
    {
        public ActorDTO Actor { get; set; }
        public string RoleName { get; set; }    
        public bool IsMainRole { get; set; }
    }
}

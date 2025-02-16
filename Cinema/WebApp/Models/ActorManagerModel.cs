using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models
{ 
    public enum ActorManagerPageMode
    {
        View,
        Select,
        Manage
    }
    public class ActorManagerModel : PageModel
    {
        public List<ActorDTO> Actors { get; set; }
        public ActorManagerPageMode PageMode { get; set; }
    }
}

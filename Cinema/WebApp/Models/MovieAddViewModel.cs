using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models
{
    public class MovieAddViewModel
    {
        public MovieDTO Movie { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
        public string GenreString {  get; set; }
        public string RoleNameString { get; set; }
        public string ActorNameString {get; set; }
        public string MainRoleString { get; set; }

    }
}

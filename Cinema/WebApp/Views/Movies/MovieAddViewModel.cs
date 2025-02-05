using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Views.Movies
{
    public class MovieAddViewModel : PageModel
    {
        public MovieDTO Movie { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
        //public IEnumerable<ActorDTO> Actors { get; set; }
    }
}

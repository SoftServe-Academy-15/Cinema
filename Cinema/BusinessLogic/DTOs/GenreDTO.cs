namespace BusinessLogic.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string GenreName { get; private set; }
        public List<MovieDTO> Movies { get; set; }
    }
}

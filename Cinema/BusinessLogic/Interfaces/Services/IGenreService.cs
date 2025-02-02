using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IGenreService : IBaseCRUD<GenreDTO>
    {
        List<GenreDTO> GetByName(string name);
        GenreDTO GetById(int id);
        List<GenreDTO> GetByIds(int[] ids);
    }
}

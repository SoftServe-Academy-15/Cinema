using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IActorService : IBaseCRUD<ActorDTO>
    {
        ActorDTO GetActorById(int id);
        List<ActorDTO> GetActorsByIds(int[] ids);
        List<ActorDTO> GetActorsByName(string name);
        List<ActorDTO> GetActorsByMovie(MovieDTO movie);
    }
}

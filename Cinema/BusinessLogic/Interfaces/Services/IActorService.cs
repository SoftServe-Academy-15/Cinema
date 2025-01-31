using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IActorService
    {
        void AddActor(ActorDTO actorDTO);
        void UpdateActor(ActorDTO actorDTO);
        void DeleteActor(int actorId);
        ActorDTO GetActorById(int id);
        List<ActorDTO> GetActorsByIds(int[] ids);
        List<ActorDTO> GetAllActors();
        List<ActorDTO> GetActorsByName();
        List<ActorDTO> GetActorsByMovie(MovieDTO movie);
    }
}

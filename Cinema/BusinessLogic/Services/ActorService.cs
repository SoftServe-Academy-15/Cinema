using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;

namespace BusinessLogic.Services
{
    public class ActorService : IActorService
    {
        public void AddActor(ActorDTO actorDTO)
        {

        }

        public void DeleteActor(int actorId)
        {
            IMovieService movieService = null;
            throw new NotImplementedException();
        }

        public ActorDTO GetActorById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ActorDTO> GetActorsByIds(int[] ids)
        {
            throw new NotImplementedException();
        }

        public List<ActorDTO> GetActorsByMovie(MovieDTO movie)
        {
            throw new NotImplementedException();
        }

        public List<ActorDTO> GetActorsByName()
        {
            throw new NotImplementedException();
        }

        public List<ActorDTO> GetAllActors()
        {
            throw new NotImplementedException();
        }

        public void UpdateActor(ActorDTO actorDTO)
        {
            throw new NotImplementedException();
        }
    }
}

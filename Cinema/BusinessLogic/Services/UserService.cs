using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services.Base;
using DataAccess.Entities;
using DataAccess.Entities.Specifications;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using static DataAccess.Entities.Specifications.UserSpecification;

namespace BusinessLogic.Services
{
    public class UserServise : BaseServiceClass<User, UserDTO>, IUserService
    {
        public UserServise(IMapper mapper, IRepository<User> repository) : base(mapper, repository)
        {
        }

        public UserDTO Authenticate(string email, string password)
        {
            var user = Repository.GetFirstBySpec(new UserSpecification.ByEmail(email));

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin
            };
        }
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return (enteredPassword == storedHash);
        }
        public UserDTO GetByEmail(string email)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ByEmail(email));
            return Mapper.Map<UserDTO>(result);
        }

        public UserDTO GetById(int id)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ById(id));
            return Mapper.Map<UserDTO>(result);
        }

        public List<UserDTO> GetByIds(int[] ids)
        {
            var result = Repository.GetListBySpec(new UserSpecification.ByIds(ids));
            return Mapper.Map<List<UserDTO>>(result);
        }

        public UserDTO GetByName(string name)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ByUserName(name));
            return Mapper.Map<UserDTO>(result);
        }

        //public List<UserDTO> GetByRole(bool[] role)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

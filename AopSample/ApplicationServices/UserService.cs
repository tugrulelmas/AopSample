using AopSample.DTOs;
using AopSample.Entities;
using AopSample.Repositories;

namespace AopSample.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepositoy;

        public UserService(IUserRepository userRepositoy) {
            this.userRepositoy = userRepositoy;
        }

        public void Add(UserDTO user) {
            var userEntity = new User(user.Name, user.Email);
            userRepositoy.Add(userEntity);
        }
    }
}
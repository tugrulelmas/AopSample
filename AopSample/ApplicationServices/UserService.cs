using AopSample.DTOs;
using AopSample.Entities;
using AopSample.Helper;
using AopSample.Repositories;
using System;
using System.Collections.Generic;

namespace AopSample.ApplicationServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepositoy;

        public UserService(IUserRepository userRepositoy) {
            this.userRepositoy = userRepositoy;
        }

        public void Add(UserDTO user) {
            var userEntity = new User(Guid.Empty, user.Name, user.Email);
            userRepositoy.Add(userEntity);
        }

        public UserDTO Get(Guid id) {
            var user = userRepositoy.Get(id);
            return user.ToDTO();
        }

        public IEnumerable<UserDTO> GetAll() {
            var users = userRepositoy.GetAll();
            return users.ToDTOs();
        }
    }
}
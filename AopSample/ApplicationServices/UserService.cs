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
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public void Add(UserDTO user) {
            var userEntity = new User(Guid.Empty, user.Name, user.Email);
            userRepository.Add(userEntity);
        }

        public UserDTO Get(Guid id) {
            var user = userRepository.Get(id);
            return user.ToDTO();
        }

        public IEnumerable<UserDTO> GetAll() {
            var users = userRepository.GetAll();
            return users.ToDTOs();
        }
    }
}
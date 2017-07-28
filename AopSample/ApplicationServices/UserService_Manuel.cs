using AopSample.DTOs;
using AopSample.Entities;
using AopSample.Repositories;
using System;

namespace AopSample.ApplicationServices.Manuel
{
    /*
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILog log;

        public UserService(IUserRepository userRepository, ILog log) {
            this.userRepository = userRepository;
            this.log = log;
        }

        public void Add(UserDTO user) {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(user.Name))
                throw new Exception("UserNameIsEmpty");

            if (string.IsNullOrEmpty(user.Email))
                throw new Exception("UserEmailIsEmpty");

            var tmpUser = userRepository.Get(user.Email);
            if (tmpUser != null)
                throw new Exception("UserIsAlreadyRegistered");

            try {
                log.Debug($"Before adding user. UserName: {user.Name}");

                var userEntity = new User(user.Name, user.Email);
                userRepository.Add(userEntity);

                log.Debug($"After adding user. UserName: {user.Name}");
            } catch (Exception ex) {
                log.Error(ex.ToString());
                throw;
            }
        }
    }
    */
}
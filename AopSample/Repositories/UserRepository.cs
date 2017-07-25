using AopSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AopSample.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IList<User> users;

        public UserRepository() {
            users = new List<User> { new User(Guid.NewGuid(), "jane@sample.com", "Jane Adey"),
                                     new User(Guid.NewGuid(), "brandon@sample.com", "Brandon Bailey")};
        }

        public void Add(User user) {

        }

        public User Get(Guid id) => users.FirstOrDefault(u => u.Id == id);

        public User Get(string email) => users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

        public IEnumerable<User> GetAll() => users;
    }
}
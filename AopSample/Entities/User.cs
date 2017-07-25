using System;

namespace AopSample.Entities
{
    public class User
    {
        public User(string name, string email) {
            Name = name;
            Email = email;
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }
    }
}
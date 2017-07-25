﻿using System;

namespace AopSample.Entities
{
    public class User
    {
        public User(Guid id, string name, string email) {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }
    }
}
using AopSample.Entities;
using System;
using System.Collections.Generic;

namespace AopSample.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        User Get(Guid id);

        /// <summary>
        /// Gets the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        User Get(string email);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Adds the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Add(User user);
    }
}
using AopSample.DTOs;
using System;
using System.Collections.Generic;

namespace AopSample.ApplicationServices
{
    public interface IUserService : IService
    {
        /// <summary>
        /// Adds the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Add(UserDTO user);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        UserDTO Get(Guid id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDTO> GetAll();
    }
}
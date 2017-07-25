using AopSample.DTOs;
using AopSample.Entities;
using System.Collections.Generic;

namespace AopSample.Helper
{
    public static class Extensions
    {
        public static UserDTO ToDTO(this User user) {
            if (user == null)
                return null;

            return new UserDTO {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };
        }

        public static IEnumerable<UserDTO> ToDTOs(this IEnumerable<User> users) {
            var result = new List<UserDTO>();
            foreach (var userItem in users) {
                result.Add(userItem.ToDTO());
            }
            return result;
        }
    }
}
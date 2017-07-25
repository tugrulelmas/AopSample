using AopSample.DTOs;

namespace AopSample.ApplicationServices
{
    public interface IUserService : IService
    {
        void Add(UserDTO user);
    }
}
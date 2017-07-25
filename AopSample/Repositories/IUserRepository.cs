using AopSample.Entities;

namespace AopSample.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);

        void Add(User user);
    }
}
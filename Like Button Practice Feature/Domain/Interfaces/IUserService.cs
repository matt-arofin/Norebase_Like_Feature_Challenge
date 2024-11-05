using Norebase_Like_Feature_Challenge.Domain.Entities;

namespace Norebase_Like_Feature_Challenge.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(string name);
    }
}

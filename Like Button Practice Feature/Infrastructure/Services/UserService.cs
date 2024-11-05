using Norebase_Like_Feature_Challenge.Domain.Entities;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;

namespace Norebase_Like_Feature_Challenge.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(string name)
        {
            var newUser = new User { Name = name };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}

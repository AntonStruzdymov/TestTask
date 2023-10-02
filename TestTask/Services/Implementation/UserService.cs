using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementation
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<User> GetUser()
        {
            var user = _context.Users.OrderByDescending(a=>a.Orders.Count).FirstOrDefault();
            return Task.FromResult(user);
        }

        public Task<List<User>> GetUsers()
        {
            var users = _context.Users.Where(a=>a.Status.Equals(UserStatus.Inactive)).ToList();
            return Task.FromResult(users);
        }
    }
}

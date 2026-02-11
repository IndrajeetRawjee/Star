using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Star.Data;
using BCrypt.Net;

namespace Star.User
{
    public class UserService : IUserService
    {
        public readonly AppDbContext _context;
        public UserService(AppDbContext context) {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}

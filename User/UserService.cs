using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Star.Data;

using Star.Password;
using System.Threading.Tasks;

namespace Star.User
{
    public class UserService : IUserService
    {
        public readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly TokenService _tokenService;
        public UserService(AppDbContext context, IPasswordService passwordService, TokenService tokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> CreateUser(RegisterDto dto)
        {
            var domainPassword = new Password(dto.Password);
            var hashedPassword = _passwordService.Hash(domainPassword);
            var user = new User
            {
                Username = dto.FirstName,
                Email = dto.Email,
                HashedPassword = hashedPassword
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<(bool IsValid, string token)> ValidateUser(LoginDto dto)
        {
            var domainPassword = new Password(dto.Password);
            var token = "";
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser == null)
            {
                return (false, string.Empty);
            }

                var isVerified = _passwordService.Verify(domainPassword, existingUser.HashedPassword);
            if (isVerified)
            {
                token = _tokenService.GenerateToken(existingUser.Email);
            }

            return (isVerified, token);
        }
    }
}
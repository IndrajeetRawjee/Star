

namespace Star.User
{
    public interface IUserService
    {
        Task<User> CreateUser(RegisterDto dto);
        Task<(bool IsValid,string token)> ValidateUser(LoginDto dto);

    }
    public interface IAdminService
    {
        Task<User> GetUser(User user);
        Task<bool> DeleteUser(User user);

    }
}
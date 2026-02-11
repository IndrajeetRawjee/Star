namespace Star.User
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser(User user);

    }
}
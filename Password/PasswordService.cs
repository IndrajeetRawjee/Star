using Star.User;
namespace Star.Password
{
    public class PasswordService
    {
        public PasswordService() { }

        public User.Password Hash(User.Password password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password.Value, salt);
            return password;
        }
    }
}

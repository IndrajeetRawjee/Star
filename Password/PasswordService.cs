using Star.User;
namespace Star.Password
{
    public class PasswordService : IPasswordService
    {
        public PasswordService() { }

        public string Hash(User.Password password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password.Value, salt);
            return hashedPassword;
        }
        public bool Verify(User.Password password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password.Value, hashedPassword);
        }
        
    }
}

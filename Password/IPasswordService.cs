
using Star.User;
namespace Star.Password
{
    public interface IPasswordService
    {
        string Hash(User.Password password);
        bool Verify(User.Password password, string hashedPassword);
    }
}
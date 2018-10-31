using Rtf.Data.Model;

namespace Rtf.Data.Abstractions.Repository
{
    public interface IUsersRepository
    {
        User Get(int id);
        User GetUser(string login, string password);
        User RegisterUser(string name, string login, string password);

    }
}
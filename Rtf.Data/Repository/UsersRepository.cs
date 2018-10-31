using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Rtf.Data.Repository
{
    using Abstractions.DataContext;
    using Abstractions.Repository;
    using Model;
    /// <summary>
    /// Users repository
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        private IDataContext _context;
        private IQueryable<User> _users;
        private IQueryable<UserCredentials> _userCredentials;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">data context</param>
        public UsersRepository(IDataContext context)
        {
            _context = context;
            _users = context.Query<User>();
            _userCredentials = context.Query<UserCredentials>();
        }

        /// <summary>
        /// Get user by login & password
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        /// <returns>User</returns>
        public User GetUser(string login, string password)
        {
            return _userCredentials
                .Where(credentials => credentials.Login == login && credentials.Password == password)
                .Include(credential=>credential.User)
                .FirstOrDefault()
                ?.User;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        public User RegisterUser(string name, string login ,string password)
        {
            var user = new User
            {
                Name = name
            };
            var credential = new UserCredentials
            {
                Login = login,
                Password = password,
                User = user
            };
            _context.Add(user);
            _context.Add(credential);
            _context.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}

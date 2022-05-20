using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Services
{
    public class UserService
    {
        private readonly SqlContext _context;
        public UserService(SqlContext context)
        {
            _context = context;
        }
        public Task Registration(User user)
        {
            var isExist = _context.Users.Any(u => u.Login == user.Login);

            if (isExist == true)
            {
                throw new Exception("This login already exists!");
            }
            _context.Add(user);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
        public Task<User> Login(string login, string password)
        {
            var user = _context.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("Invalid login or password");
            }
            return Task.FromResult(user);

        }
    }
}

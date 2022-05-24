using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using System;
using System.Collections.Generic;
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

        public List<City> GetFavourites(int userId)
        {
            var cityIds = _context.UserCity.Where(x => x.UserId == userId).Select(x => x.CityId).ToList();
            var cities = _context.Cities.Where(x => cityIds.Contains(x.Id)).ToList();
            return cities;
        }

        public void SetFavourites(int userId, string cityName)
        {
            var cityId = _context.Cities.FirstOrDefault(x => x.Name == cityName)?.Id;
            if (cityId == null)
            {
                throw new Exception("Incorrect city name!");
            }
            if (_context.UserCity.Any(x => x.CityId == cityId && x.UserId == userId))
            {
                throw new Exception("City is already exists in your favourites!");
            }
            _context.UserCity.Add(new UserCity(userId, (int)cityId));
            _context.SaveChanges();
        }

        public void RemoveFavourites(int userId, string cityName)
        {
            var cityId = _context.Cities.FirstOrDefault(x => x.Name == cityName)?.Id;
            if (cityId == null)
            {
                throw new Exception("Incorrect city name!");
            }
            if (_context.UserCity.FirstOrDefault(x => x.CityId == cityId && x.UserId == userId) == null)
            {
                throw new Exception("You don`t have city in your favourites!");
            }
            var city = _context.UserCity.FirstOrDefault(x => x.CityId == cityId && x.UserId == userId);
            _context.UserCity.Remove(city);
            _context.SaveChanges();
        }
    }
}

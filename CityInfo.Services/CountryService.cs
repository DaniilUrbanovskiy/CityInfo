using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.Services
{
    public class CountryService
    {
        private readonly SqlContext _context;
        public CountryService(SqlContext context)
        {
            _context = context;
        }

        public List<City> GetCities(string enteredCountry) 
        {
            var country = _context.Countries.FirstOrDefault(c => c.Name == enteredCountry);

            var cityList = _context.Cities.Where(c => c.CountryId == country.Id).ToList();

            return cityList;
        }
    }
}

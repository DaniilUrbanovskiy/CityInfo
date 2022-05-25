using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Services
{
    public class CityService
    {
        private readonly SqlContext _context;
        public CityService(SqlContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetCities(string countryName)
        {
            var cityList = new List<City>();
            if (countryName == null)
            {
                cityList = await _context.Cities.ToListAsync();
            }
            else
            {
                var country = _context.Countries.FirstOrDefault(c => c.Name == countryName);
                if (country == null)
                {
                    throw new Exception("Incorrect country name");
                }
                cityList = await _context.Cities.Where(c => c.CountryId == country.Id).ToListAsync();
            }
            return cityList;
        }
    }
}
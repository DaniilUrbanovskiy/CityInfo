using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Services
{
    public class CountryService
    {
        private readonly SqlContext _context;
        public CountryService(SqlContext context)
        {
            _context = context;
        }
        public async Task<List<Country>> GetCountries()
        {
            var countryList = await _context.Countries.ToListAsync();

            return countryList;
        }
    }
}

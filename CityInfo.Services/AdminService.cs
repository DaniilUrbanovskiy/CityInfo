using CityInfo.DataAccess;
using CityInfo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CityInfo.Services
{
    public class AdminService
    {
        private readonly SqlContext _context;
        public AdminService(SqlContext context)
        {
            _context = context;
        }

        public Task AddCountry(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
using AutoMapper;
using CityInfo.Api.Dto.Responses;
using CityInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(CountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetCountries();

            var countries = _mapper.Map<List<CountryResponse>>(result);

            return Ok(countries);
        }
    }
}
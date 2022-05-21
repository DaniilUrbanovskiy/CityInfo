using AutoMapper;
using CityInfo.Api.Dto.Requests;
using CityInfo.Api.Dto.Responses;
using CityInfo.Domain.Entities;
using System.Collections.Generic;

namespace CityInfo.Api.Infrastructure
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<UserRegisterRequest, User>();
            CreateMap<Country, CountryResponse>();
            CreateMap<City, CityResponse>();
        }
    }
}

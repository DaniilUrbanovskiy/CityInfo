using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace CityInfo.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public List<City> Citys { get; set; }
    }
}

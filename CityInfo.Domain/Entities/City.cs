using System;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string Info { get; set; }
        public int CountryId { get; set; }
    }
}

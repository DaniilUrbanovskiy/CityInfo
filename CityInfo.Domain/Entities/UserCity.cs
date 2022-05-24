using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Domain.Entities
{
    public class UserCity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }

        public UserCity(int userId, int cityId)
        {
            this.UserId = userId;
            this.CityId = cityId;
        }
    }
}

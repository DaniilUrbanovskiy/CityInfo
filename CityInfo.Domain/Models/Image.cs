using System.IO;

namespace CityInfo.Domain.Models
{
    public class Image
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Stream Body { get; set; }
    }
}

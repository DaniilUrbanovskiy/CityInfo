namespace CityInfo.Api.Dto.Responses
{
    public class CityResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string CityImage { get; set; }
        public int CountryId { get; set; }
    }
}

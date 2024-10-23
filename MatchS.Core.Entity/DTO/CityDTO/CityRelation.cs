namespace MatchS.Core.Entity.DTO.Cities
{
    public class CityRelation
    {
        public string Country { get; set; }
        public string Code { get; set; }
        public List<City> City { get; set; }
    }

    public class City
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<string> District { get; set; }
    }
}
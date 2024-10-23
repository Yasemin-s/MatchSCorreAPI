namespace MatchS.Core.Common.City
{
    public interface ICityCommon
    {
        public Task<(string cityName, string districtName)> GetCityInformation(int userId);
        public (string cityName, string districtName) GetCityInformation(string cityId, string districtId);
    }
}
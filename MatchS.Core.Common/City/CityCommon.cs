using MatchS.Core.Entity.DTO.Cities;
using MatchS.Core.Service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MatchS.Core.Common.City
{
    public class CityCommon : ICityCommon
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public CityCommon(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public (string cityName, string districtName) GetCityInformation(string cityId, string districtId)
        {
            var cityRelationData = _configuration.GetSection("CityRelation").Get<CityRelation>();
            var cityData = cityRelationData.City.FirstOrDefault(x => x.Code == cityId);
            int districtIndex = int.Parse(districtId);
            var districtName = cityData.District[districtIndex - 1];

            return (cityData.Name, districtName);
        }
        public async Task<(string cityName, string districtName)> GetCityInformation(int userId)
        {
            var userData = await _userService.GetFirstOrDefaultAsync(x => x.Id == userId);
            var cityRelationData = _configuration.GetSection("CityRelation").Get<CityRelation>();
            var cityData = cityRelationData.City.FirstOrDefault(x => x.Code == userData.CityId);
            int districtIndex = int.Parse(userData.DistrictId);
            var districtName = cityData.District[districtIndex - 1];

            return (cityData.Name, districtName);
        }
    }
}
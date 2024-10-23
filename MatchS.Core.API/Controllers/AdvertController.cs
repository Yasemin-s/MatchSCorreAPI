using AutoMapper;
using MatchS.Core.Common.City;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.AdvertDTO;
using MatchS.Core.Entity.DTO.Cities;
using MatchS.Core.Entity.DTO.UserDTO;
using MatchS.Core.Service.Interfaces;
using MatchS.Core.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ICityCommon _cityCommon;



        public AdvertController(ICityCommon cityCommon, IAdvertService advertService, IMapper mapper, IUserService userService)
        {
            _advertService = advertService;
            _mapper = mapper;
            _userService = userService;
            _cityCommon = cityCommon;
        }

        //[HttpGet("Cities")]
        //public async Task<IActionResult> GetCity()
        //{
        //    var cityData = _configuration.GetSection("CityRelation").Get<CityRelation>();

        //    return Ok(await _advertService.GetFilterListAsync(x => x.IsActive == true));
        //}

        [HttpGet("MyAdverts")]
        public async Task<IActionResult> MyAdverts()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var cityData = await _cityCommon.GetCityInformation(id);
            var advertList = await _advertService.GetFilterListByNoTrackAsync(x => x.IsActive == true && x.UserId == id);
            var advertListDTO = _mapper.Map<List<ListAdvertDTO>>(advertList);
            foreach (var advertDataDTO in advertListDTO)
            {
                advertDataDTO.CityId = cityData.cityName;
                advertDataDTO.DistrictId = cityData.districtName;
            }
            return Ok(advertListDTO);
        }

        [HttpGet("GetAdvertsByCity")]
        public async Task<IActionResult> GetAdvertsByCity()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userData = await _userService.GetFirstOrDefaultAsync(u => u.Id == id);
            var city = userData.CityId;
            var advertList = await _advertService.GetFilterListByNoTrackAsync(x => x.IsActive == true && x.CityId == city);
            var advertListDTO = _mapper.Map<List<ListAdvertDTO>>(advertList);
            var cityData = await _cityCommon.GetCityInformation(id);

            foreach (var advertDataDTO in advertListDTO)
            {
                advertDataDTO.CityId = cityData.cityName;
                advertDataDTO.DistrictId = cityData.districtName;
            }
            return Ok(advertListDTO);
        }
        [HttpGet("GetAdverts")]
        public async Task<IActionResult> GetAdverts()
        {
            var advertList = await _advertService.GetFilterListByNoTrackAsync(x => x.IsActive == true);
            var advertListDTO = _mapper.Map<List<ListAdvertDTO>>(advertList);

            foreach (var advertDataDTO in advertListDTO)
            {
                var cityData = _cityCommon.GetCityInformation(advertDataDTO.CityId, advertDataDTO.DistrictId);

                advertDataDTO.CityId = cityData.cityName;
                advertDataDTO.DistrictId = cityData.districtName;
            }
            return Ok(advertListDTO);
        }

        [HttpPost("AddAdvert")]
        public async Task<IActionResult> AddAdvert([FromBody] AddAdvertDTO addAdvertDTO)
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userData = await _userService.GetFirstOrDefaultAsync(u => u.Id == id);
            var advertData = _mapper.Map<Advert>(addAdvertDTO);
            advertData.CityId = userData.CityId;
            advertData.DistrictId = userData.DistrictId;
            advertData.UserId = userData.Id;
            await _advertService.InsertAsync(advertData);
            return Ok();
        }
        [HttpPut("UpdateAdvert")]
        public async Task<IActionResult> UpdateAdvert([FromBody] UpdateAdvertDTO updateAdvertDTO)
        {
            var oldAdvertData = await _advertService.GetFirstOrDefaultAsync(x => x.Id == updateAdvertDTO.Id);

            if (oldAdvertData != null)
            {
                var advertData = _mapper.Map<Advert>(updateAdvertDTO);
                oldAdvertData.UpdatedAt = DateTime.Now;
                oldAdvertData.Title = advertData.Title;
                oldAdvertData.Content = advertData.Content;
                oldAdvertData.RequiredUserCount = advertData.RequiredUserCount;
                oldAdvertData.GameDate = advertData.GameDate;
                oldAdvertData.IsActive = advertData.IsActive;
                await _advertService.UpdateAsync(oldAdvertData);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("DeleteAdvert")]
        public async Task<IActionResult> DeleteAdvert(int id)
        {
            await _advertService.DeleteAsync(await _advertService.GetFirstOrDefaultAsync(x => x.Id == id));
            return Ok();
        }
        [HttpGet("GetAdvertById")]
        public async Task<IActionResult> GetAdvertById(int id)
        {
            var advertData = await _advertService.GetFirstOrDefaultAsync(x => x.Id == id);
            var advertDTO = _mapper.Map<GetAdvertDTO>(advertData);
            var cityData = _cityCommon.GetCityInformation(advertDTO.CityId, advertDTO.DistrictId);
            advertDTO.CityId = cityData.cityName;
            advertDTO.DistrictId = cityData.districtName;
            return Ok(advertDTO);
        }
    }
}
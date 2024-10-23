using AutoMapper;
using MatchS.Core.Common.City;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.Cities;
using MatchS.Core.Entity.DTO.UserDTO;
using MatchS.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ICityCommon _cityCommon;
        public UserController(IUserService userService, IMapper mapper, ICityCommon cityCommon)
        {
            _userService = userService;
            _mapper = mapper;
            _cityCommon = cityCommon;
        }

        [HttpPut("profildüzenle")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDTO updateUserDTO)
        {
            var userData = _mapper.Map<User>(updateUserDTO);
            userData.Id = Convert.ToInt32(User.Claims.FirstOrDefault().Value);
            userData.UpdatedAt = DateTime.Now;
            await _userService.UpdateAsync(userData);
            return Ok();
        }
        [HttpGet("profilbilgi")]
        public async Task<IActionResult> ProfileInformation()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userData = await _userService.GetFirstOrDefaultAsync(x => x.Id == id);
            var userDTOData = _mapper.Map<GetUserDTO>(userData);
            var cityInformation = await _cityCommon.GetCityInformation(id);
            userDTOData.CityId = cityInformation.cityName;
            userDTOData.DistrictId = cityInformation.districtName;
            return Ok(userDTOData);
        }
        [HttpDelete("hesapsil")]
        public async Task<IActionResult> DeleteProfile()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _userService.DeleteAsync(await _userService.GetFirstOrDefaultAsync(x => x.Id == id));
            await HttpContext.SignOutAsync();
            return Ok(id);
        }
        [HttpPost("çıkışyap")]
        public async Task<IActionResult> LogOut()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await HttpContext.SignOutAsync();
            return Ok(id);
        }

        [HttpGet("şehrimigetir")]
        public async Task<IActionResult> GetMyCity()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var cityData = await _cityCommon.GetCityInformation(userId);
            return Ok($"Şehir: {cityData.cityName}, İlçe: {cityData.districtName}");
        }
    }
}
using AutoMapper;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.UserDTO;
using MatchS.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("kayitol")]
        public async Task<IActionResult> Register([FromBody] AddUserDTO addUserDTO)
        {
            var userData = _mapper.Map<User>(addUserDTO);
            await _userService.InsertAsync(userData);
            return Created();
        }
        [HttpPost("girisyap")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var userData = await _userService.LoginAsync(loginUserDTO.UserName, password: loginUserDTO.Password);

            if (userData == null)
                return Unauthorized("Kullanıcı Bulunamadı.");

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, userData.Id.ToString()),
                new (JwtRegisteredClaimNames.Name, userData.UserName),
                new (JwtRegisteredClaimNames.NameId, userData.Id.ToString()),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
               issuer: "yasemin",
               audience: "yaso",
               claims: claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yasemininsifresi24karakterliolsun")),
                   SecurityAlgorithms.HmacSha256)
           );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
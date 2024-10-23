using AutoMapper;
using MatchS.Core.Entity.Core;
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

        [HttpPost("kayıtol")]
        public async Task<IActionResult> Register([FromBody] AddUserDTO addUserDTO)
        {
            var userData = _mapper.Map<User>(addUserDTO);
            await _userService.InsertAsync(userData);
            return Created();
        }
        [HttpPost("girişyap")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var userData = await _userService.LoginAsync(loginUserDTO.UserName, password: loginUserDTO.Password);
            GetUserDTO? userDTOData = null;

            if (userData != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,userData.Id.ToString()),
                    new Claim(ClaimTypes.Name,userData.UserName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "User");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                userDTOData = _mapper.Map<GetUserDTO>(userData);
            }

            return Ok(userDTOData == null ? "Kullanıcı Bulunamadı." : userDTOData);
        }
    }
}
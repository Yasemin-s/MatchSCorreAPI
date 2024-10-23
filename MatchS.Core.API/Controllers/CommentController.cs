using AutoMapper;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.AdvertDTO;
using MatchS.Core.Entity.DTO.CommentDTO;
using MatchS.Core.Service.Interfaces;
using MatchS.Core.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchS.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public CommentController(ICommentService commentService, IMapper mapper, IUserService userService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCommentDTO addCommentDTO)
        {
            var commentData = _mapper.Map<Comment>(addCommentDTO);

            commentData.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _commentService.InsertAsync(commentData);
            return Created();
        }

    }
}

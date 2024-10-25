using AutoMapper;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.CommentDTO;
using MatchS.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment([FromBody] AddCommentDTO addCommentDTO)
        {
            var commentData = _mapper.Map<Comment>(addCommentDTO);
            commentData.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _commentService.InsertAsync(commentData);
            return Ok("Yorum Oluşturuldu");
        }
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteAsync(await _commentService.GetFirstOrDefaultAsync(x => x.Id == id));
            return Ok("Yorum Silindi.");
        }
    }
}
using AutoMapper;
using MatchS.Core.Entity.Core;
using MatchS.Core.Entity.DTO.MessageDTO;
using MatchS.Core.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet("GetMyMailBox")]
        public async Task<IActionResult> GetMyMailBox()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var receivedMessages = await _messageService.GetFilterListByNoTrackAsync(x => x.ReceiverId == id);
            var sentMessages = await _messageService.GetFilterListByNoTrackAsync(x => x.SenderId == id);
            var allMessages = receivedMessages.Concat(sentMessages);
            var distinctMessages = allMessages
                .GroupBy(m => new { m.ReceiverId, m.SenderId }) 
                .Select(g => g.First())
                .ToList();

            var messageListDTO = distinctMessages.Select(m => new ListMessageDTO
            {
                Content = m.Content,
                CreatedAt = m.CreatedAt,
                ReceiverId = m.ReceiverId == id ? m.SenderId : m.ReceiverId, 
                SenderId = m.SenderId == id ? m.ReceiverId : m.SenderId, 
                UserType = m.ReceiverId == id ? "Gönderen" : "Alıcı" 
            }).ToList();

            return Ok(messageListDTO);
        }

        [HttpGet("GetMyReceiveMessage")]
        public async Task<IActionResult> GetMyReceiveMessage()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var myMessages = await _messageService.GetFilterListByNoTrackAsync(x => x.ReceiverId == id );
            var messageListDTO = _mapper.Map<List<ListMessageDTO>>(myMessages);
            return Ok(messageListDTO);
        }

        [HttpGet("GetMySentMessage")]
        public async Task<IActionResult> GetMySentMessage()
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var myMessages = await _messageService.GetFilterListByNoTrackAsync(x => x.SenderId == id);
            var messageListDTO = _mapper.Map<List<ListMessageDTO>>(myMessages);
            return Ok(messageListDTO);
        }

        [HttpGet("GetMyChatMessages")]
        public async Task<IActionResult> GetMyChatMessages(int targetUserId)
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var receivedMessages = await _messageService.GetFilterListByNoTrackAsync(x => x.ReceiverId == targetUserId && x.SenderId == id);
            var sentMessages = await _messageService.GetFilterListByNoTrackAsync(x => x.SenderId == targetUserId && x.ReceiverId == id);

            var messageListDTO = receivedMessages.Select(m => new ListMessageDTO
            {
                Content = m.Content,
                CreatedAt = m.CreatedAt,
                ReceiverId = m.ReceiverId,
                SenderId = m.SenderId,
                UserType = "Gönderen"
            })
            .Concat(sentMessages.Select(m => new ListMessageDTO
            {
                Content = m.Content,
                CreatedAt = m.CreatedAt,
                ReceiverId = m.ReceiverId,
                SenderId = m.SenderId,
                UserType = "Alıcı"
            }))
            .OrderBy(m => m.CreatedAt)
            .ToList();

            return Ok(messageListDTO);
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] AddMessageDTO addMessageDTO)
        {
            int id = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var messageData = _mapper.Map<Message>(addMessageDTO);
            messageData.SenderId = id; 
            await _messageService.InsertAsync(messageData);
            return Ok("Mesaj Gönderildi.");
        }

        [HttpDelete("DeleteMessage")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteAsync(await _messageService.GetFirstOrDefaultAsync(x => x.Id == id));
            return Ok("Mesaj Silindi.");
        }
    }
}
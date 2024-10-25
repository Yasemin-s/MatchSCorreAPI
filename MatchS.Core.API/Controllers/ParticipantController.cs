using AutoMapper;
using MatchS.Core.Entity.DTO.ParticipantDTO;
using MatchS.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;

        public ParticipantController(IParticipantService participantService, IMapper mapper, IAdvertService advertService)
        {
            _participantService = participantService;
            _mapper = mapper;
            _advertService = advertService;
        }

        [HttpPost("AddParticipant")]
        public async Task<IActionResult> AddParticipant(int advertId)
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _participantService.InsertAsync(new()
            {
                AdvertId = advertId,
                Score = 0,
                UserId = userId,
            });
            return Ok("Katılım Başvurusu Oluşturuldu.");
        }

        [HttpGet("GetParticipantByAdvert")]
        public async Task<IActionResult> GetParticipantByAdvert(int advertId)
        {
            var participants = await _participantService.GetFilterListByNoTrackAsync(x => x.AdvertId == advertId && x.IsAccepted == true);
            var advertsDTO = _mapper.Map<List<ListParticipantDTO>>(participants);
            return Ok(advertsDTO);
        }

        [HttpGet("GetMyAdvertsParticipantsNotifications")]
        public async Task<IActionResult> GetMyAdvertsParticipantsNotifications(int advertId)
        {
            var participants = await _participantService.GetFilterListByNoTrackAsync(x => x.AdvertId == advertId && x.IsAccepted == false);
            var participantsDTO = _mapper.Map<List<ListParticipantDTO>>(participants);
            return Ok(participantsDTO);
        }

        [HttpGet("AcceptParticipantNotification")]
        public async Task<IActionResult> AcceptParticipantNotification(int advertId, int userId)
        {
            var participant = await _participantService.GetFirstOrDefaultAsync(x => x.AdvertId == advertId && x.UserId == userId);
            participant.IsAccepted = true;
            await _participantService.UpdateAsync(participant);
            return Ok("Katılım İsteği Kabul Edildi.");
        }

        [HttpGet("DeclineParticipantNotification")]
        public async Task<IActionResult> DeclineParticipantNotification(int advertId, int userId)
        {
            var participant = await _participantService.GetFirstOrDefaultAsync(x => x.AdvertId == advertId && x.UserId == userId);
            participant.IsActive = false;
            await _participantService.UpdateAsync(participant);
            return Ok("Katılım İsteği Reddedildi.");
        }

        [HttpGet("MyParticipantNotifications")]
        public async Task<IActionResult> MyParticipantNotifications()
        {
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var participants = await _participantService.GetFilterListByNoTrackAsync(x => x.UserId == userId);
            var participantsDTO = _mapper.Map<List<ListParticipantDTO>>(participants);
            return Ok(participantsDTO);
        }
    }
}
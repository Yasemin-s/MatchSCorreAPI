using MatchS.Core.Entity.Core;

namespace MatchS.Core.Entity.DTO.ParticipantDTO
{
    public class ListParticipantDTO
    {
        public int UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsAccepted { get; set; } = false;
        public bool? IsActive { get; set; }
        public Score? Score { get; set; }
        public int AdvertId { get; set; }
    }
}
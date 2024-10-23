using System.Xml.Linq;

namespace MatchS.Core.Entity.Core
{
    public class Advert : BaseModal
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime GameDate { get; set; }
        public byte RequiredUserCount { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? CityId { get; set; }
        public string? DistrictId { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Participant>? Participants { get; set; }
    }
}
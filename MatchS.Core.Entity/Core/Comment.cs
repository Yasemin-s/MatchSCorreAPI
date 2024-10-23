using System.ComponentModel.DataAnnotations.Schema;

namespace MatchS.Core.Entity.Core
{
    public class Comment : BaseModal
    {
        public int UserId { get; set; }
        public int AdvertId { get; set; }
        public string Content { get; set; }
        public User? User { get; set; }
        public Advert? Advert { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchS.Core.Entity.Core
{
    public class Message : BaseModal
    {
        public string Content { get; set; }
        public DateTime SentDate { get; set; }
        public int SenderId { get; set; }
        public User? Sender { get; set; }
        public int ReceiverId { get; set; }
        public User? Receiver { get; set; }
    }
}
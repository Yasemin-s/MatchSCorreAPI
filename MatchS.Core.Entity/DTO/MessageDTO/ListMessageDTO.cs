namespace MatchS.Core.Entity.DTO.MessageDTO
{
    public class ListMessageDTO
    {
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int ReceiverId{ get; set; }
        public int SenderId { get; set; }
        public string UserType { get; set; } 
    }
}
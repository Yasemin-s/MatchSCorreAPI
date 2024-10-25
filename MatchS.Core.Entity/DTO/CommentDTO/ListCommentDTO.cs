namespace MatchS.Core.Entity.DTO.CommentDTO
{
    public class ListCommentDTO
    {
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId{ get; set; }
    }
}
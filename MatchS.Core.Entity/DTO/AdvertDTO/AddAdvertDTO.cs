namespace MatchS.Core.Entity.DTO.AdvertDTO
{
    public class AddAdvertDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime GameDate { get; set; }
        public byte RequiredUserCount { get; set; }
        public int CategoryId { get; set; }
    }
}
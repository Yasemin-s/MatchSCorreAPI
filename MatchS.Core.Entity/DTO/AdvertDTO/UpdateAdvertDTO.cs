namespace MatchS.Core.Entity.DTO.AdvertDTO
{
    public class UpdateAdvertDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? GameDate { get; set; } = DateTime.Now.AddDays(3);
        public byte RequiredUserCount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
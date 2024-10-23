namespace MatchS.Core.Entity.DTO.AdvertDTO
{
    public class GetAdvertDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime GameDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte RequiredUserCount { get; set; }
        public int CategoryId { get; set; }
        public string? CityId { get; set; }
        public string? DistrictId { get; set; }
    }
}
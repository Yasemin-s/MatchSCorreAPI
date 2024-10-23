namespace MatchS.Core.Entity.Core
{
    public class User : BaseModal
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Photo { get; set; }
        public byte Age { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }

        public ICollection<Advert>? Adverts { get; set; }
        public ICollection<Participant>? Participants { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Message>? SentMessages { get; set; }
        public ICollection<Message>? ReceivedMessages { get; set; }
    }
}
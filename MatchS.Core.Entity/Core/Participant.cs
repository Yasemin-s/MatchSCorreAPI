namespace MatchS.Core.Entity.Core
{
    public class Participant : BaseModal
    {
        public int AdvertId { get; set; }
        public int UserId { get; set; }
        public DateTime ParticipantDate { get; set; }
        public bool IsAccepted { get; set; } = false;
        public Score? Score { get; set; }
        public User? User { get; set; }
        public Advert? Advert { get; set; }
    }
    public enum Score
    {
        Poor = 1, //Kötü
        Fair = 2, // Zayıf
        Average = 3, //Orta
        Good = 4, //İyi
        Excellent = 5 //Çok iyi 
    }
}
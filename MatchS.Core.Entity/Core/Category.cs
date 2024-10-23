namespace MatchS.Core.Entity.Core
{
    public class Category : BaseModal
    {
        public string Name { get; set; }
        public ICollection<Advert>? Adverts { get; set; }
    }
}
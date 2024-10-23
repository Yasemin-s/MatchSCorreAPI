using System.ComponentModel.DataAnnotations;

namespace MatchS.Core.Entity.Core
{
    public class BaseModal
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
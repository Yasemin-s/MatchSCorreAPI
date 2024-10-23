namespace MatchS.Core.Entity.DTO.UserDTO
{
    public class UpdateUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Photo { get; set; }
        public byte Age { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.Entities
{
    public class ProfileEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }


        
        public UserEntity Address { get; set; } = null!;

    }
}

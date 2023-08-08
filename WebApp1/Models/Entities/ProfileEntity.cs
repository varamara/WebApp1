using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp1.Models.Identity;

namespace WebApp1.Models.Entities
{
    public class ProfileEntity
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }

        public UserEntity User { get; set; } = null!;

    }
}

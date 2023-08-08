namespace WebApp1.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Email { get; set; }
        public byte[] Password { get; set; } = null!;
        public byte[] SecurityKey { get; set; } = null!;
    }
}


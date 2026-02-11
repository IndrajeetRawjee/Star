namespace Star.User
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public required string Email { get; set; }
        public required string HashedPassword { get; set; }
        public bool isAdmin { get; set; } = false;
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}

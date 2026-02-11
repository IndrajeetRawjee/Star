namespace Star.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public readonly record struct Password
    {
        public string Value { get; init; }
        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
            {
                throw new ArgumentException("Password cannot be null, whitespace or less than 8 char.", nameof(value));
            }
            Value = value;
        }
    }
}

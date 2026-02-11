
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Star.User
{
    public record RegisterDto(
        [Required, EmailAddress] string Email, 
        [Required, MinLength(8)] string Password, 
        [Required]string FirstName);
    public record LoginDto(string Email, string Password);
    public readonly record struct Password(string Value)
    {
        public override string ToString() => "********"; 

    }
}


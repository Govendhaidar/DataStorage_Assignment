using System.ComponentModel.DataAnnotations;

namespace Business.DTOs;

public class UserRegistrationForm
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
}

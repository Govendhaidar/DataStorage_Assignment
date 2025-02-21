using System.ComponentModel.DataAnnotations;

namespace Business.DTOs;

public class StatusTypeRegistrationForm
{
    [Required]
    public string StatusName { get; set; } = null!;


}

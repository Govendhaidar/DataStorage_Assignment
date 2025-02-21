using System.ComponentModel.DataAnnotations;

namespace Business.DTOs;

public class ProjectUpdateForm
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ProductId { get; set; }

}

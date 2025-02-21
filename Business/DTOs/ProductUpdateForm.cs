using System.ComponentModel.DataAnnotations;

namespace Business.DTOs;

public class ProductUpdateForm
{
    [Required]
    public int Id {  get; set; }

    [Required]
    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    [Required]
    public decimal ProductPrice { get; set; }

}

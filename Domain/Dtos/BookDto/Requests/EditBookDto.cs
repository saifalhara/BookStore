using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.BookDto.Requests;

public class EditBookDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    public IFormFile Book { get; set; } = null!;

    [Required]
    public double Rank { get; set; }
}

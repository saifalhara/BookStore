using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.BookDto.Responses;

public class BookResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string BookUrl {  get; set; } = string.Empty;

    public IFormFile Book { get; set; } = null!;

    public int Rank { get; set; }
}

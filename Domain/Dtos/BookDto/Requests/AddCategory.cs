using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.BookDto.Requests;

public class AddCategory
{
    [Required]
    [Range(1 , int.MaxValue)]
    public int Id { get; set; }

    [Required]
    public Category Category { get; set; }
}

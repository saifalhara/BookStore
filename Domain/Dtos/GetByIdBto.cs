using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class GetByIdBto
{
    [Required]
    public int Id { get; set; }
}

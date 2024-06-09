using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Sheard;

public class GetByIdBto
{
    [Required]
    public int Id { get; set; }
}

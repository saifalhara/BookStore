using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Sheard;

public class Delete
{
    [Required]
    public int Id { get; set; }
}

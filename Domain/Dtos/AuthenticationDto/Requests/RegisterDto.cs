using Domain.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.UserDtos.Requests;

public class UserDto
{
    [Required]
    [RegularExpression(EmailRegexDefaults.Standard)]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(PasswordRegexDefault.Standard)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string UserName { get; set; } = null!;
}

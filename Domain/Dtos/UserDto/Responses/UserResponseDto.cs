namespace Domain.Dtos.UserDto.Responses;

public class UserResponseDto
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserName { get; set; } = null!;
    public DateTime CreatedDate { get; set; } 
    public DateTime EditDate { get; set;}
}
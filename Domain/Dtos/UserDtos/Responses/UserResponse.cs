namespace Domain.Dtos.UserDtos.Responses;
public record UserResponse(
     int Id ,
     string Email,
     string UserName ,
     string token 
);
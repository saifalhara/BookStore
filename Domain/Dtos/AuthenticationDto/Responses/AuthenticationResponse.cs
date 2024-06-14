namespace Domain.Dtos.UserDtos.Responses;
public record struct AuthenticationResponse(
     int Id ,
     string Email,
     string UserName ,
     string token 
);
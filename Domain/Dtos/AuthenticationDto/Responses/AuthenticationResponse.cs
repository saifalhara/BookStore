namespace Domain.Dtos.UserDtos.Responses;
public record AuthenticationResponse(
     int Id ,
     string Email,
     string UserName ,
     string token 
);
namespace Domain.Dtos.UserDto.Responses;

public record struct UserResponseDto(
      int Id , 
      string Email  ,
      string Password  ,
      string UserName  ,
      DateTime CreatedDate  ,
      DateTime EditDate  ,
      DateTime ReadTo  ,
      DateTime ReadFrom
);
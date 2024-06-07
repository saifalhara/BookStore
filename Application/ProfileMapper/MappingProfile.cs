using AutoMapper;
using Domain.Dtos.BookDto.Requests;
using Domain.Dtos.BookDto.Responses;
using Domain.Dtos.UserDtos.Requests;
using Domain.Entity;

namespace Application.ProfileMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginDto>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();    
        CreateMap<EditBookDto, Book>().ReverseMap();    
        CreateMap<BookResponseDto, Book>().ReverseMap();    
    }
}

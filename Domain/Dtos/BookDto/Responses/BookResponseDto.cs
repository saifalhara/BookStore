using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.BookDto.Responses;

public record struct  BookResponseDto(
    int Id ,
    string Name ,
    string Title ,
    string Description ,
    string Author ,
    string BookUrl ,
    string FileName ,
    double Rank 
    );

﻿using Domain.Abstractions;
using Domain.Dtos.BookDto.Requests;

namespace Domain.InterfaceServices;

public interface IBooksServices
{
    Task<Result> Create(BookDto book);
    Task<Result> Update(int Id , BookDto book);
    Task<Result> Delete(DeleteBookDto book);
    Task<Result> GetAll();
    Task<Result> GetById(int id);
}

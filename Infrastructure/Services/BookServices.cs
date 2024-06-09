using AutoMapper;
using Domain.Abstractions;
using Domain.Dtos.BookDto.Requests;
using Domain.Dtos.BookDto.Responses;
using Domain.Entity;
using Domain.InterfaceRebositorys.UnitOfWork;
using Domain.InterfaceServices;
using Infrastructure.Errors.BooksError;

namespace Infrastructure.Services;
public class BookServices(
        IUnitOfWork _unitOfWork,
        IMapper _mapper ,
        IFireBaseServices _fireBaseServices
    ) : IBooksServices
{
    /// <summary>
    /// Create New Book In Date Base
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns>Return The Result If Data Saved Or No</returns>
    public async Task<Result> Create(BookDto bookDto)
    {
        var book = _mapper.Map<BookDto, Book>(bookDto);
        book.BookUrl = await _fireBaseServices.Upload(bookDto.Book);
        book.CreateDate = DateTime.Now;
        await _unitOfWork._GenericBookRepository.Create(book);
        if (_unitOfWork.SaveChanges() <= 0)
        { return Result.Failure(); }
        return Result.Success();
    }

    /// <summary>
    /// Delete Book 
    /// </summary>
    /// <param name="bookDto"></param> 
    /// <returns>Return The Result About Status If Data Deleted Or Not</returns>
    public async Task<Result> Delete(DeleteBookDto bookDto)
    {
        var book = await GetById(bookDto.Id);
        if (book.IsError)
        {
            return BooksError.BookDoesNotExist;
        }
        var deleteBook = (Book?)book.Response ?? new();
        deleteBook.IsDeleted = true;
        deleteBook.EditDate = DateTime.Now;
        _unitOfWork._GenericBookRepository.Delete(deleteBook);
        return (await _unitOfWork.SaveChangesAsync() > 0) ? Result.Success() : Result.Failure();
    }

    /// <summary>
    /// Get All Book From Data Base
    /// </summary>
    /// <returns></returns>
    public async Task<Result> GetAll()
    {
        var books = await _unitOfWork._GenericBookRepository.Get();
        var bookResponse = _mapper.Map<List<Book>, List<BookResponseDto>>(books);
        return books == null ? BooksError.NoBookFound : Result.Success(books);
    }

    /// <summary>
    /// Get Book By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return The Book By Id</returns>
    public async Task<Result> GetById(int id)
    {
        var book = await _unitOfWork._GenericBookRepository.GetByExpression((x => x.Id == id));
        var bookResponse = _mapper.Map<Book, BookResponseDto>(book);
        return (book is null) ? BooksError.NoBookFound : Result.Success(bookResponse);
    }

    /// <summary>
    /// Updat Book By Book Dto
    /// </summary>
    /// <param name="bookDto"></param>
    /// <returns>Result About Status Of Save User</returns>
    public async Task<Result> Update(int Id, BookDto bookDto)
    {
        var updateBook = new Book()
        {
            Id = Id,
            Author = bookDto.Author,
            Name = bookDto.Name,
            Description = bookDto.Description,
            Title = bookDto.Title,
            BookUrl = await _fireBaseServices.Upload(bookDto.Book),
            Rank = bookDto.Rank,
            EditDate = DateTime.Now,
        };
        _unitOfWork._GenericBookRepository.Update(updateBook);
        return (_unitOfWork.SaveChanges() > 0) ? Result.Success() : Result.Failure();
    }
}
using BookStore.Controllers.Base;
using Domain.Dtos;
using Domain.Dtos.BookDto.Requests;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Books;

[Route("api/[controller]")]
[ApiController]
public class BooksController(IBooksServices _booksServices) : BaseController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] BookDto book)
    {
        try
        {
            var result = await _booksServices.Create(book);
            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _booksServices.GetAll();
            return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }

    [HttpGet]
    [Route("GetById/{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        try
        {
            var result = await _booksServices.GetById(Id);
            return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteBookDto bookDto)
    {
        try
        {
            var result = await _booksServices.Delete(bookDto);
            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromForm] EditBookDto bookDto)
    {
        try
        {
            var result = await _booksServices.Update(bookDto);
            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
        catch
        {
            throw;
        }
    }
}

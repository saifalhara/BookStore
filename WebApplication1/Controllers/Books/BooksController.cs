using BookStore.Controllers.Base;
using Domain.Dtos.BookDto.Requests;
using Domain.Dtos.Sheard;
using Domain.Entity;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Books;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class BooksController(IBooksServices _booksServices) : BaseController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] BookDto book)
    {
        var result = await _booksServices.Create(book);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        var result = await _booksServices.GetAll();
        return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
    }

    [HttpGet]
    [Route("GetById/{Id:int}")]
    public async Task<IActionResult> GetById(int Id)
    {
        var result = await _booksServices.GetById(Id);
        return result.IsSuccess ? Ok(result.Response) : BadRequest(result.Error);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete([FromBody] Delete bookDto)
    {
        var result = await _booksServices.Delete(bookDto);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpPut]
    [Route("Update/{Id:int}")]
    public async Task<IActionResult> Update(int Id, [FromForm] BookDto bookDto)
    {
        var result = await _booksServices.Update(Id, bookDto);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    [HttpPost]
    [Route("AddCateory")]
    public async Task<IActionResult> AddCateory(int Id, List<Category> categorys)
    {
        var result = await _booksServices.AddCateorys(Id, categorys);
        return result.IsSuccess ? NoContent() : BadRequest();
    }

    [HttpDelete]
    [Route("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(int Id, Category categorys)
    {
        var result = await _booksServices.DeleteCategory(Id, categorys);
        return result.IsSuccess ? NoContent() : BadRequest();
    }
}

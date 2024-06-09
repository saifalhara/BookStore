using Microsoft.AspNetCore.Http;

namespace Domain.InterfaceServices;

public interface IFireBaseServices
{
    Task<string> Upload(IFormFile book);
}
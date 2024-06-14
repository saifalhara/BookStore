using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Domain.InterfaceServices;

public interface IFireBaseServices
{

    /// <summary>
    /// Upload File To FireBase
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    Task<(string, string)> Upload(IFormFile book);

    /// <summary>
    /// Download File From FireBase
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    Task<(byte[], string, string)> Download(string fileName);
}
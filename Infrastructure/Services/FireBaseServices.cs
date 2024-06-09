using Domain.InterfaceServices;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class FireBaseServices : IFireBaseServices
{
    public readonly FireBaseOptions _options; 

    public FireBaseServices(IOptions<FireBaseOptions> options)
    {
        _options = options.Value;
    }

    /// <summary>
    /// Upload File To FireBase
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public async Task<string> Upload(IFormFile book)
    {
        using (var memoryStream = new MemoryStream())
        {
            await book.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var task = new FirebaseStorage(_options.Bucket)
                .Child("Book")
                .Child(book.FileName)
                .PutAsync(memoryStream);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            var downloadUrl = await task;
            return downloadUrl;
        }
    }
}

using Domain.InterfaceServices;
using Firebase.Storage;
using Infrastructure.Options.FireBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Infrastructure.FirebaseServices;

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
    public async Task<(string , string)> Upload(IFormFile book)
    {
        var fileName = book.FileName;
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
            return (downloadUrl , fileName);
        }
    }

    /// <summary>
    /// Download File From FireBase
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public async Task<(byte[] , string , string)> Download(string fileName)
    {
        var downloadUrl = await new FirebaseStorage(_options.Bucket)
            .Child("Book")
            .Child(fileName)
            .GetDownloadUrlAsync();

        using (var httpClient = new HttpClient())
        {
            var bookBytes = await httpClient.GetByteArrayAsync(downloadUrl);
            string contentType = "application/pdf";
            return (bookBytes, contentType, fileName);
        }
    }
}

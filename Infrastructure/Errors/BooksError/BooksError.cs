using Domain.Abstractions;
using System.Diagnostics.Eventing.Reader;

namespace Infrastructure.Errors.BooksError;

public class BooksError
{
    public static Error BookDoesNotExist = new("BookDoesNotExist", "Book Does Not Exist");
    public static Error BookAlreadyExist = new("BookAlreadyExist", "Book Already Exist");
    public static Error NoBookFound = new("NoBookFounded", "No Book Founded");
}

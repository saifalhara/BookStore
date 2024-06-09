using Domain.Entity.Relations;

namespace Domain.Entity;

public class Book : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Rank { get; set; }
    public string BookUrl { get; set; } = null!;
    public string Author { get; set; }= null!;

    #region Navigation Prorerty
    public ICollection<BookCategorys>? BookCategorys { get; set; }
    public ICollection<User>? User { get; set; }
    public ICollection<UserBooks>? UserBooks { get; set; }
    #endregion

}

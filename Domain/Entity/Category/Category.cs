using Domain.Entity.Relations;

namespace Domain.Entity;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<BookCategorys>? BookCategorys { get; set; }
}

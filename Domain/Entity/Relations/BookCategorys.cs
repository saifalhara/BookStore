using Domain.Entity.Relations;

namespace Domain.Entity;

public class BookCategorys : BaseEntity
{
    public int BookId { get; set; }
    public Book? Book { get; set; }
    public Category? Catigory { get; set; }
}

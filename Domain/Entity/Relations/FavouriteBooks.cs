namespace Domain.Entity.Relations;
public class FavouriteBooks : BaseEntity
{
    public int UserId { get; set; }
    public int BookId { get; set; }

    public User? User { get; set; }
    public Book? Book { get; set; }
}
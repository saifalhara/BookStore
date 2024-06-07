namespace Domain.Entity.Relations;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EditDate { get; set; }
    public bool IsDeleted { get; set; }
}

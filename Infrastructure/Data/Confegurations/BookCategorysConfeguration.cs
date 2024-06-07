using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Confegurations;
public class BookCategorysConfeguration : IEntityTypeConfiguration<BookCategorys>
{
    public void Configure(EntityTypeBuilder<BookCategorys> builder)
    {
        builder.HasKey(bc => new { bc.CategoryId, bc.BookId });
        builder.HasOne(bc => bc.Book);
        builder.HasOne(bc=> bc.Catigory);
    }
}

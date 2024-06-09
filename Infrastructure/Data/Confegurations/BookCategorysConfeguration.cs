using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Confegurations;
public class BookCategorysConfeguration : IEntityTypeConfiguration<BookCategorys>
{
    public void Configure(EntityTypeBuilder<BookCategorys> builder)
    {
        builder.HasKey(bc => new { bc.BookId, bc.Catigory });
        builder.HasOne(bc => bc.Book);
        builder.Property(bc => bc.Catigory)
                          .HasConversion<int>();
    }
}

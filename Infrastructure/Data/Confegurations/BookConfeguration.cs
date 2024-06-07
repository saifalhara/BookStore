using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Confegurations;

public class BookConfeguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasQueryFilter(b => !b.IsDeleted);
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(b => b.Description)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(b => b.Name)
            .IsRequired();
        builder.Property(b => b.BookUrl)
            .IsRequired();
        builder.Property(b => b.Author)
            .IsRequired();
        builder.HasMany(b => b.BookCategorys);
        builder.HasMany(b => b.UserBooks);
    }
}

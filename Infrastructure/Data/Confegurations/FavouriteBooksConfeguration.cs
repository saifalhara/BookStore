using Domain.Entity.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Confegurations;

public class FavouriteBooksConfeguration : IEntityTypeConfiguration<FavouriteBooks>
{
    public void Configure(EntityTypeBuilder<FavouriteBooks> builder)
    {
        builder.HasKey(fb => new{fb.BookId, fb.UserId});
        builder.HasOne(fb => fb.User);
        builder.HasOne(fb => fb.Book);
    }
}

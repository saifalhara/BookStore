using Domain.Entity.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Confegurations;

public class UserBooksConfeguration : IEntityTypeConfiguration<UserBooks>
{
    public void Configure(EntityTypeBuilder<UserBooks> builder)
    {
        builder.HasKey(ub => new { ub.UserId , ub.BookId});
        builder.HasOne(ub => ub.Book);
        builder.HasOne(ub => ub.User);
        builder.HasQueryFilter(ub => !ub.IsDeleted);
    }
}

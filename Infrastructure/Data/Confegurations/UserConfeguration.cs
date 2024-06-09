using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Confeguration;
public class UserConfeguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.Password)
            .IsRequired();
        builder.HasMany(u => u.FavouriteBooks);
        builder.HasMany(u => u.UserBooks);
        builder.HasQueryFilter(u => !u.IsDeleted);
    }
}

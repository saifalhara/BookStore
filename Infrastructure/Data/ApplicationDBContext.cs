using Domain.Entity;
using Domain.Entity.Relations;
using Infrastructure.Data.Confeguration;
using Infrastructure.Data.Confegurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : DbContext(option)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookCategorys> BookCatigories { get; set; }
    public DbSet<FavouriteBooks> FavouriteBooks { get; set; }
    public DbSet<UserBooks> UserBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BookConfeguration());
        modelBuilder.ApplyConfiguration(new CategoryConfeguration());
        modelBuilder.ApplyConfiguration(new BookCategorysConfeguration());
        modelBuilder.ApplyConfiguration(new UserConfeguration());
        modelBuilder.ApplyConfiguration(new UserBooksConfeguration());
        modelBuilder.ApplyConfiguration(new FavouriteBooksConfeguration());

    }
}

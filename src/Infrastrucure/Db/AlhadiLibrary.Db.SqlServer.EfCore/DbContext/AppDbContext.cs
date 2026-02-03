using System.Runtime;
using AlhadiLibrary.Domain.Core.BookAgg.Entities;
using AlhadiLibrary.Domain.Core.CategoryAgg.Entities;
using AlhadiLibrary.Domain.Core.CommentAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlhadiLibrary.Db.SqlServer.EfCore.DbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<BookTranslator> BookTranslators { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

    }
}
using AlhadiLibrary.Domain.Core.BookAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlhadiLibrary.Db.SqlServer.EfCore.EntityConfigs;

public class BookConfigs : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder.ToTable("Books");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(x => x.Price)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(x => x.PageCount)
               .IsRequired();

        builder.Property(x => x.ImagePath)
               .HasMaxLength(500);

        builder.HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Authors)
               .WithOne(x => x.Book)
               .HasForeignKey(x => x.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Translators)
               .WithOne(x => x.Book)
               .HasForeignKey(x => x.BookId)
               .OnDelete(DeleteBehavior.Cascade);


        builder.HasIndex(x => x.Title);

        builder.HasIndex(x => new { x.Title, x.CategoryId })
               .IsUnique(false);

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
    }
}
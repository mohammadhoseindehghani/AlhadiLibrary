using AlhadiLibrary.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlhadiLibrary.Db.SqlServer.EfCore.EntityConfigs;

public class BookTranslatorConfigs : IEntityTypeConfiguration<BookTranslator>
{
    public void Configure(EntityTypeBuilder<BookTranslator> builder)
    {
        builder.ToTable("BookTranslators");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.Translators)
            .HasForeignKey(x => x.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Translator)
            .WithMany()
            .HasForeignKey(x => x.TranslatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.BookId, x.TranslatorId })
            .IsUnique();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}
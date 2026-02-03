
using AlhadiLibrary.Domain.Core._common;
using AlhadiLibrary.Domain.Core.BookAgg.Entities;

namespace AlhadiLibrary.Domain.Core.UserAgg.Entities;

public class BookTranslator : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public int TranslatorId { get; set; }
    public ApplicationUser Translator { get; set; }
}
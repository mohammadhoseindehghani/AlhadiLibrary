namespace AlhadiLibrary.Domain.Core.BookAgg.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    public string ImagePath { get; set; }

    public string CategoryTitle { get; set; }

    public List<string> Authors { get; set; }
    public List<string> Translators { get; set; }
}

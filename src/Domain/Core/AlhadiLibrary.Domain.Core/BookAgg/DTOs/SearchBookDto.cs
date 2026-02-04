namespace AlhadiLibrary.Domain.Core.BookAgg.DTOs;

public class SearchBookDto
{
    public string? Title { get; set; }
    public string? AuthorFirstName { get; set; }
    public string? AuthorLastName { get; set; }
    public string? TranslatorFirstName { get; set; }
    public string? TranslatorLastName { get; set; }
    public int? CategoryId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? MinPageCount { get; set; }
    public int? MaxPageCount { get; set; }
}

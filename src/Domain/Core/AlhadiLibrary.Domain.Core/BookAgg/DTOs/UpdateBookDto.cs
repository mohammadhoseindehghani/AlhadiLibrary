namespace AlhadiLibrary.Domain.Core.BookAgg.DTOs;

public class UpdateBookDto
{
    public int Id { get; set; }

    public string Title { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }
    public string ImagePath { get; set; }
    public int CategoryId { get; set; }

    public List<int> AuthorIds { get; set; }
    public List<int> TranslatorIds { get; set; }
}
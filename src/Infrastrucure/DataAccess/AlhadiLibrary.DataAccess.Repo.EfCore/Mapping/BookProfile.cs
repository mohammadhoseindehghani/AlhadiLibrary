using AlhadiLibrary.Domain.Core.BookAgg.DTOs;
using AlhadiLibrary.Domain.Core.BookAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Entities;
using AutoMapper;

namespace AlhadiLibrary.DataAccess.Repo.EfCore.Mapping;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>()
            .ForMember(dest => dest.Authors,
                opt => opt.MapFrom(src =>
                    src.AuthorIds.Select(id =>
                        new BookAuthor { AuthorId = id })))
            .ForMember(dest => dest.Translators,
                opt => opt.MapFrom(src =>
                    src.TranslatorIds.Select(id =>
                        new BookTranslator { TranslatorId = id })));

        CreateMap<UpdateBookDto, Book>()
            .ForMember(dest => dest.Authors, opt => opt.Ignore())
            .ForMember(dest => dest.Translators, opt => opt.Ignore());

        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.CategoryTitle,
                opt => opt.MapFrom(src => src.Category.Title))
            .ForMember(dest => dest.Authors,
                opt => opt.MapFrom(src =>
                    src.Authors.Select(a =>
                        a.Author.FirstName + " " + a.Author.LastName)))
            .ForMember(dest => dest.Translators,
                opt => opt.MapFrom(src =>
                    src.Translators.Select(t =>
                        t.Translator.FirstName + " " + t.Translator.LastName)));
    }
}
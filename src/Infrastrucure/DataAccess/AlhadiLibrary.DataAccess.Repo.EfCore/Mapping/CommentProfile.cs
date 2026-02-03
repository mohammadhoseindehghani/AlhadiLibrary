using AlhadiLibrary.Domain.Core.CommentAgg.DTOs;
using AlhadiLibrary.Domain.Core.CommentAgg.Entities;
using AutoMapper;

namespace AlhadiLibrary.DataAccess.Repo.EfCore.Mapping;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<CreateCommentDto, Comment>()
            .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(_ => false))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());

        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.UserFullName,
                opt => opt.MapFrom(src =>
                    src.ApplicationUser.FirstName + " " +
                    src.ApplicationUser.LastName));
    }
}
using AlhadiLibrary.Domain.Core._common;
using AlhadiLibrary.Domain.Core.CommentAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Enums;

namespace AlhadiLibrary.Domain.Core.UserAgg.Entities;

public class User : BaseEntity
{
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string MobileNumber { get;  set; }
    public string? ProfileImagePath { get;  set; }
    public decimal Balance { get;  set; }

    public string IdentityUserId { get;  set; }

    public UserRoleEnum Role { get;  set; }
    public ICollection<Comment> Comments { get;  set; } = new List<Comment>();

}
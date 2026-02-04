using AlhadiLibrary.Domain.Core._common;
using AlhadiLibrary.Domain.Core.CommentAgg.Entities;
using AlhadiLibrary.Domain.Core.UserAgg.Enums;
using Microsoft.AspNetCore.Identity;

namespace AlhadiLibrary.Domain.Core.UserAgg.Entities;

public class ApplicationUser : IdentityUser<int>
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string FirstName { get;  set; }
    public string LastName { get;  set; }
    public string Email { get;  set; }
    public string MobileNumber { get;  set; }
    public string? ProfileImagePath { get;  set; }
    public decimal Balance { get;  set; }

    public int IdentityUserId { get; set; }

    public UserRoleEnum Role { get;  set; }
    public ICollection<Comment> Comments { get;  set; } = new List<Comment>();
}
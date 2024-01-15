using Api.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Api.Infrastructure.Persistent.Models;

public sealed class UserModel : IdentityUser
{
    internal static UserModel Empty => new();

    public string Avatar { get; } = string.Empty;
    public JobTitle JobTitle { get; }

    public ICollection<TaskModel> Tasks { get; set; } = Array.Empty<TaskModel>();
}

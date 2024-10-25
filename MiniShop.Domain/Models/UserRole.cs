using MiniShop.Domain.Common;

namespace MiniShop.Domain.Models;

public record class UserRole : BaseModel
{
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
using MiniShop.Domain.Common;

namespace MiniShop.Domain.Models;

public record class User : BaseModel
{
    public string Nickname { get; set; }

    public Guid RoleUserId { get; set; }
    public virtual UserRole RoleUser { get; set; }

    public virtual ICollection<Check> Checks { get; set; }
}
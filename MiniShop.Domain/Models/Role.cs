using MiniShop.Domain.Common;

namespace MiniShop.Domain.Models;

public record class Role : BaseModel
{
    public string Type { get; set; }
}
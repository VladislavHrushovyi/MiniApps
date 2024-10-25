using MiniShop.Domain.Common;

namespace MiniShop.Domain.Models;

public record class Product : BaseModel
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public int Amount { get; set; }
    
    public virtual ICollection<Check> Checks { get; set; }
}
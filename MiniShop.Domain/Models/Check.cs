using MiniShop.Domain.Common;

namespace MiniShop.Domain.Models;

public record class Check : BaseModel
{
    public decimal TotalCost { get; set; }
    public int TotalAmount { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public List<Product> Products { get; set; } // must be json column
}
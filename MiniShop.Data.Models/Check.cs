namespace MiniShop.Data.Models;

public class Check : BaseModel
{
    public decimal TotalCost { get; set; }
    public int TotalProduct { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
}
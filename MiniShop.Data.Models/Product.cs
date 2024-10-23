namespace MiniShop.Data.Models;

public class Product : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public decimal Amount { get; set; }
}
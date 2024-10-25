namespace MiniShop.Domain.Common;

public record class BaseModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
}
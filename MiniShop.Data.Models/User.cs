namespace MiniShop.Data.Models;

public class User : BaseModel
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public int UserRoleId { get; set; }
    public virtual UserRole UserRole { get; set; }

    public virtual ICollection<Check> Checks { get; set; }
}
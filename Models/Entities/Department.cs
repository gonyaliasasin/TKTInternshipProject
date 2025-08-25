namespace Taskms.Api.Models.Entitys;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public List<User> Users { get; set; } 
}

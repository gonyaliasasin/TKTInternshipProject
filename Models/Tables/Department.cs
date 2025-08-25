namespace Taskms.Api.Models.Tables;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public List<User> Users { get; set; } 
}

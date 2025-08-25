namespace Taskms.Api.Models.Tables;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Title { get; set; }

    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
}
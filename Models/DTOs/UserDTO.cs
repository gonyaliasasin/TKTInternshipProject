namespace Taskms.Api.Models.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public string Title { get; set; }
    public string Role  { get; set; }
}
namespace TktInternshipProject.Models.DTOs;

public class TaskCreateDTO
{
    public Guid AssignedDepartmentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
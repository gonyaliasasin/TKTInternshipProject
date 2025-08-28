namespace Taskms.Api.Models.DTOs;

public class TaskUpdateDTO
{
    public Guid Id { get; set; }
    public Guid AssignedDepartmentId { get; set; }
    public int Status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RejectReason { get; set; }
}
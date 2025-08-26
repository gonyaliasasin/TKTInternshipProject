namespace Taskms.Api.Models.DTOs;

public class TaskItemDTO
{
    public Guid Id { get; set; }
    public string CreatedByUserName { get; set; }
    public string AssignedDepartmentName { get; set; }
    public string Status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RejectReason { get; set; }
    public DateTime CreatedAt { get; set; }
}
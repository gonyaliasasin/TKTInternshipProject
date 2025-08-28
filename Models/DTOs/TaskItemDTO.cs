namespace TktInternshipProject.Models.DTOs;

public class TaskItemDTO
{
    public Guid Id { get; set; }
    public Guid CreatedByUserId { get; set; }
    public Guid AssignedDepartmentId { get; set; }
    public Status Status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RejectReason { get; set; }
    public DateTime CreatedAt { get; set; }
}
namespace TktInternshipProject.Models.Entities;

public class TaskItem : BaseEntity
{
    public Status Status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RejectReason { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid CreatedByUserId { get; set; }
    public User CreatedByUser { get; set; }

    public Guid AssignedDepartmentId { get; set; }
    public Department AssignedDepartment { get; set; }
}
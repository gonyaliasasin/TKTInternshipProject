namespace Taskms.Api.Mappers;

public static class TaskMapper
{
    // Entity --> DTO
    public static TaskItemDTO ToDTO(TaskItem task)
    {
        return new TaskItemDTO
        {
            Id = task.Id,
            CreatedByUserName = task.CreatedByUser?.Name + " " + task.CreatedByUser?.Surname,
            AssignedDepartmentName = task.AssignedDepartment?.Name,
            Status = task.Status.ToString(),
            Title = task.Title,
            Description = task.Description,
            RejectReason = task.RejectReason,
            CreatedAt = task.CreatedAt
        };
    }

    // DTO --> Entity (Create)
    public static TaskItem ToEntity(TaskCreateDTO dto, Guid createdByUserId, Guid assignedDepartmentId)
    {
        return new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = Status.Pending,
            AssignedDepartmentId = assignedDepartmentId,
            CreatedByUserId = createdByUserId,
            CreatedAt = DateTime.UtcNow
        };
    }

    // DTO --> Entity (Update)
    public static void UpdateEntity(TaskItem task, TaskUpdateDTO dto)
    {
        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Status = Enum.Parse<Status>(dto.Status);
        task.AssignedDepartmentId = dto.AssignedDepartmentId;
        task.RejectReason = dto.RejectReason;
    }
}

namespace Taskms.Api.Mappers;

public static class TaskMapper
{
    // Entity --> DTO
    public static TaskItemDTO ToDTO(TaskItem task)
    {
        return new TaskItemDTO
        {
            Id = task.Id,
            CreatedByUserId = task.CreatedByUserId,
            AssignedDepartmentId = task.AssignedDepartmentId,
            Status = task.Status,
            Title = task.Title,
            Description = task.Description,
            RejectReason = task.RejectReason,
            CreatedAt = task.CreatedAt
        };
    }

    // DTO --> Entity (Create)
    public static TaskItem ToEntity(TaskCreateDTO dto, Guid createdByUserId)
    {
        return new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = Status.Pending,
            AssignedDepartmentId = dto.AssignedDepartmentId,
            CreatedByUserId = createdByUserId,
            CreatedAt = DateTime.UtcNow
        };
    }

    // DTO --> Entity (Update)
    public static void UpdateEntity(TaskItem task, TaskUpdateDTO dto)
    {
        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Status = dto.Status;
        task.AssignedDepartmentId = dto.AssignedDepartmentId;
        task.RejectReason = dto.RejectReason;
    }
}

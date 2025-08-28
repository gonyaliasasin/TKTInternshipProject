namespace TktInternshipProject.Mappers;

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
        if (!string.IsNullOrWhiteSpace(dto.Title))
            task.Title = dto.Title;
        if (!string.IsNullOrWhiteSpace(dto.Description))
            task.Description = dto.Description;
        if (Enum.IsDefined(typeof(Status), dto.Status))
            task.Status = (Status)dto.Status;
        if (dto.AssignedDepartmentId != Guid.Empty)
            task.AssignedDepartmentId = dto.AssignedDepartmentId;
        if (!string.IsNullOrWhiteSpace(dto.RejectReason))
            task.RejectReason = dto.RejectReason;
    }
}

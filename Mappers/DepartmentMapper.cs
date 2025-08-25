namespace Taskms.Api.Mappers;
public class DepartmentMapper
{
    public static DepartmentDTO ToDTO(Department department)
    {
        return new DepartmentDTO
        {
            Id = department.Id,
            Name = department.Name
        };
    }
}
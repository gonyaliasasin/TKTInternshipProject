namespace Taskms.Api.Mappers;

public class UserMapper
{
    //Entity --> DTO
    public static UserDTO ToDTO(User user, Department department)
    {
        return new UserDTO
        {
            Name = user.Name,
            SurName = user.SurName,
            Email = user.Email,
            Title = user.Title,
            DepartmentName = department.Name
        };
    }

    //DTO --> Entity
    public static User ToEntity(UserDTO dto, int departmentId)
    {
        return new User
        {
            Name = dto.Name,
            SurName = dto.SurName,
            Email = dto.Email,
            Title = dto.Title,
            Department = null!
        };
    }

}

namespace Taskms.Api.Mappers;

public class UserMapper
{
    public static UserDTO ToDTO(User user, Department department)
    {
        return new UserDTO
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Title = user.Title,
            Department = user.Department.Name
        };
    }

    public static User ToEntity(UserDTO dto, int departmentId)
    {
        return new User
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Title = dto.Title,
            Department = null!
        };
    }

}

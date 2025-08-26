using Microsoft.AspNetCore.Routing.Constraints;

namespace Taskms.Api.Mappers;

public class UserMapper
{
    public static UserDTO ToDTO(User user, Department department)
    {
        return new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Title = user.Title,
            Department = user.Department.Name,
            Role = user.Role
        };
    }
}

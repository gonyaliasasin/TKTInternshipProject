namespace TktInternshipProject.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}
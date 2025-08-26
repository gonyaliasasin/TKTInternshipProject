namespace Taskms.Api.Controllers;

[Route("api/Users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;
    private readonly IJwtService _jwtService;

    public UsersController(ApplicationDbContext db, IConfiguration configuration, IJwtService jwtService)
    {
        _db = db;
        _configuration = configuration;
        _jwtService = jwtService;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLoginDTO loginDto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

        if (user == null)
            return Unauthorized("Email or password incorrect");

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpGet("Users")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        var userList = await _db.Users
        .Include(a => a.Department)
        .OrderBy(u => u.DepartmentId)
        .ThenBy(u => u.Role == "Manager" ? 0 : 1)
        .ThenBy(u => u.Name)
        .ToListAsync();
        var userDTOs = userList.Select(u => UserMapper.ToDTO(u, u.Department)).ToList();
        return Ok(userDTOs);
    }
}
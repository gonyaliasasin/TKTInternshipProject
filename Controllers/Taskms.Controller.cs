namespace Taskms.Api.Controllers;

[Route("api/TaskMS")]
[ApiController]
public class TaskMSController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public TaskMSController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        IEnumerable<User> userList = await _db.Users.Include(u => u.Department).ToListAsync();
        var userDTOs = userList.Select(u => UserMapper.ToDTO(u, u.Department)).ToList();
        return Ok(userDTOs);
    }
}
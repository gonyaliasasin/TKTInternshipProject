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
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        IEnumerable<User> userList = await _db.Users.ToListAsync();
        return Ok(userList);
    }
}
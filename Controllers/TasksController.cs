namespace Taskms.Api.Controllers;

[Route("Tasks")]
[ApiController]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;
    private readonly IJwtService _jwtService;

    public TasksController(ApplicationDbContext db, IConfiguration configuration, IJwtService jwtService)
    {
        _db = db;
        _configuration = configuration;
        _jwtService = jwtService;
    }

    [HttpGet("Tasks")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetTasks()
    {
        var taskList = await _db
        .Tasks.Include(t => t.CreatedByUser)
        .Include(t => t.AssignedDepartment)
        .ToListAsync();
        var taskDTOs = taskList.Select(t => TaskMapper.ToDTO(t)).ToList();
        return Ok(taskDTOs);
    }

}

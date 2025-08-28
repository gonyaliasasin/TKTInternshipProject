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

    [HttpGet("All")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaskItemDTO>>> All()
    {
        var taskList = await _db
        .Tasks.Include(t => t.CreatedByUser)
        .Include(t => t.AssignedDepartment)
        .ToListAsync();
        var taskDTOs = taskList.Select(t => TaskMapper.ToDTO(t)).ToList();
        return Ok(taskDTOs);
    }

    [HttpPost("CreateTask")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] TaskCreateDTO createDto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(userIdClaim.Value);
        var department = await _db.Departments.FirstOrDefaultAsync(d => d.Name.ToLower() == createDto.AssignedDepartmentName.ToLower());

        if (department == null)
            return NotFound($"Department '{createDto.AssignedDepartmentName}' not found.");
        if (createDto.Title == null || createDto.Description == null)
            return BadRequest("Title and Description are required.");
        var taskEntity = TaskMapper.ToEntity(createDto, userId, department.Id);

        _db.Tasks.Add(taskEntity);
        await _db.SaveChangesAsync();

        return Created();
    }

    // [HttpPatch("UpdateTask/{id}")]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
}
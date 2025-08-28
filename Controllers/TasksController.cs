namespace TktInternshipProject.Controllers;

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


    [HttpGet("CreatedByMe")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaskItemDTO>>> CreatedByMe()
    {
        var userIdClaim = User.FindFirst("userId");
        var userId = Guid.Parse(userIdClaim.Value);
        var taskList = await _db
        .Tasks
        .Where(t => t.CreatedByUserId == userId)
        .Include(t => t.CreatedByUser)
        .Include(t => t.AssignedDepartment)
        .ToListAsync();
        var taskDTOs = taskList.Select(t => TaskMapper.ToDTO(t)).ToList();

        return Ok(taskDTOs);
    }


    [HttpGet("MyDepartment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaskItemDTO>>> MyDepartment()
    {
        var userDepartmentIdClaim = User.FindFirst("departmentId");
        var userDepartmentId = Guid.Parse(userDepartmentIdClaim.Value);
        var taskList = await _db
        .Tasks
        .Where(t => t.AssignedDepartmentId == userDepartmentId)
        .Include(t => t.CreatedByUser)
        .Include(t => t.AssignedDepartment)
        .ToListAsync();
        var taskDTOs = taskList.Select(t => TaskMapper.ToDTO(t)).ToList();

        return Ok(taskDTOs);
    }


    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] TaskCreateDTO createDto)
    {
        var userIdClaim = User.FindFirst("userId");
        var userId = Guid.Parse(userIdClaim.Value);

        if (createDto == null)
            return BadRequest("Invalid data.");
        if (createDto.Title == null)
            return BadRequest("Title is required.");
        if (createDto.Description == null)
            return BadRequest("Description is required.");
        if (createDto.AssignedDepartmentId == Guid.Empty)
            return BadRequest("AssignedDepartmentId is required.");

        var taskEntity = TaskMapper.ToEntity(createDto, userId);

        _db.Tasks.Add(taskEntity);
        await _db.SaveChangesAsync();

        return Created();
    }


    [HttpPatch("UpdateTaskByMe")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Update([FromBody] TaskUpdateDTO updateDto)
    {
        if (updateDto == null)
            return BadRequest("Invalid data.");

        var userIdClaim = User.FindFirst("userId");
        var userId = Guid.Parse(userIdClaim.Value);
        var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == updateDto.Id);

        if (task == null)
            return NotFound("Task not found.");

        if (task.CreatedByUserId != userId)
            return BadRequest("You can only update tasks assigned by you");

        TaskMapper.UpdateEntity(task, updateDto);
        await _db.SaveChangesAsync();

        return NoContent();
    }


    [HttpPatch("UpdateStatusByDepartment")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateStatus([FromBody] TaskUpdateDTO updateDto)
    {
        if (updateDto == null)
            return BadRequest("Invalid data.");
        if (!Enum.IsDefined(typeof(Status), updateDto.Status))
            return BadRequest("Invalid status value.");

        var userDepartmentIdClaim = User.FindFirst("departmentId");
        var userDepartmentId = Guid.Parse(userDepartmentIdClaim.Value);
        var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == updateDto.Id);

        if (task == null)
            return NotFound("Task not found.");

        if (task.AssignedDepartmentId != userDepartmentId)
            return BadRequest("You can only update tasks assigned to your department");

        TaskMapper.UpdateEntity(task, updateDto);
        await _db.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("DeleteTaskByMe")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromBody] GuidDTO request)
    {
        var taskId = request.Id;
        
        if (taskId == Guid.Empty)
            return BadRequest("Invalid task ID.");

        var userIdClaim = User.FindFirst("userId");
        var userId = Guid.Parse(userIdClaim.Value);
        var task = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

        if (task == null)
            return NotFound("Task not found.");

        if (task.CreatedByUserId != userId)
            return BadRequest("You can only delete tasks created by you");

        _db.Tasks.Remove(task);
        await _db.SaveChangesAsync();

        return NoContent();
    }    

}
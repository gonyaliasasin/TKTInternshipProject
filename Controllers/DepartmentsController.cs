namespace Taskms.Api.Controllers;

[Route("Departments")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public DepartmentsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartments()
    {
        var departmentList = await _db.Departments.ToListAsync();
        var departmentDTOs = departmentList.Select(d => DepartmentMapper.ToDTO(d)).ToList();
        return Ok(departmentDTOs);
    }
}
namespace TktInternshipProject.Controllers;

[Route("Departments")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public DepartmentsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet("All")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartments()
    {
        var departmentList = await _db.Departments.ToListAsync();
        var departmentDTOs = departmentList.Select(d => DepartmentMapper.ToDTO(d)).ToList();
        return Ok(departmentDTOs);
    }
}
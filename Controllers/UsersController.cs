using Microsoft.AspNetCore.Authorization;

namespace Taskms.Api.Controllers;

[Route("api/Users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;

    public UsersController(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
    }
    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            }),
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["DurationInMinutes"])),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"],
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] UserLoginDTO loginDto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

        if (user == null)
            return Unauthorized("Email or password incorrect");

        var token = GenerateJwtToken(user);
        return Ok(new { token = token });
    }
    
    [HttpGet("Users")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        IEnumerable<User> userList = await _db.Users.Include(u => u.Department).ToListAsync();
        var userDTOs = userList.Select(u => UserMapper.ToDTO(u, u.Department)).ToList();
        return Ok(userDTOs);
    }
}
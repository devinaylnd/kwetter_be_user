using Microsoft.AspNetCore.Mvc;
using kwetter_user.Services;
using kwetter_user.DbContext;
using kwetter_user.Models.User;

namespace kwetter_user.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _service;

    public UserController(ILogger<UserController> logger, IConfiguration configuration, ApplicationDbContext context, IUserService service)
    {
        _service       = service;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<UserResponse>> CreateUser(CreateUserRequest data)
    {
        var user = await _service.CreateUser(new UserEntity
        {
            email = data.email,
            name = data.name,
            username = data.username,
            bio = data.bio,
            location = data.location,
            userPic = data.userPic,
            createdAt = data.createdAt,
            accessToken = data.accessToken,
        });

        if (user == null) { return BadRequest(); }
        return Ok(new UserResponse(user));
    }

    [HttpPut]
    [Route("edit")]
    public async Task<ActionResult<UserResponse>> EditUser(EditUserRequest data)
    {
        var user = await _service.EditUser(new UserEntity
        {
            id = data.id,
            email = data.email,
            name = data.name,
            username = data.username,
            bio = data.bio,
            location = data.location,
            userPic = data.userPic,
            createdAt = data.createdAt,
            accessToken = data.accessToken,
        });

        if (user == null) { return NotFound(); }
        return Ok(new UserResponse(user));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<UserResponse>> GetUser(int id)
    {
        var user = await _service.GetUser(id);

        if (user == null) { return NotFound(); }
        return Ok(new UserResponse(user));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _service.DeleteUser(id);

        if (!user) { return NotFound(); }
        return Ok();
    }
}

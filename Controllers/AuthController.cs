// ต้อง import ตรงนี้ถ้า UserService อยู่ใน folder Services
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _userService.UsernameExistsAsync(request.Username))
        {
            return BadRequest(new { message = "Username already exists" });
        }

        var user = new User
        {
            Username = request.Username,
            Password = request.Password,
            Fullname = request.Fullname,
            Phone_number = request.Phone_number,
            Email = request.Email
        };

        await _userService.CreateAsync(user);
        return Ok(new { message = "Register successful", username = user.Username });
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userService.AuthenticateAsync(request.Username, request.Password);
        if (user == null)
            return Unauthorized(new { message = "Invalid credentials" });

        return Ok(new { message = "Login success", username = user.Username });
    }


    
}

using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // ✅ POST: /api/user/like
        [HttpPost("like")]
        public async Task<IActionResult> LikeBook([FromBody] LikeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserId) || string.IsNullOrWhiteSpace(request.BookId))
            {
                return BadRequest(new { message = "UserId and BookId are required." });
            }

            var success = await _userService.AddLikeAsync(request.UserId, request.BookId);

            if (!success)
                return BadRequest(new { message = "Already liked." });

            return Ok(new { message = "Book liked successfully." });
        }
    }
}

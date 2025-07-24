using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using BookShop.Models;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BooksController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://api.itbook.store/1.0/search/mysql");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error from external API.");
            }

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<BookApiResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (result?.Books == null)
            {
                return NotFound("No books found.");
            }

            //เรียง A-Z
            var sortedBooks = result.Books.OrderBy(b => b.Title).ToList();

            return Ok(sortedBooks);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MovieFinder.Entities;
using MovieFinder.Services;

namespace MovieFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieApiService _service;
        public MoviesController(IMovieApiService service)
        {
            _service = service;
        }

        [HttpGet("getBySearch")]
        public async Task<IActionResult> GetSearchedMovie(string searchedWord)
        {
            
            var movies = await _service.GetMoviesByName(searchedWord);

            return Ok(movies);
        }
    }
}

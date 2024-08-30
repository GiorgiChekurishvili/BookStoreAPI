using BookStore.DTOs;
using BookStore.Services.GenreService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet("viewallgenres")]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> ViewAllGenres()
        {
            var genres = await _genreService.GetGenres();
            return Ok(genres);
        }
        [HttpGet("viewgenrebyid/{id}")]
        public async Task<ActionResult<GenreDTO>> ViewGenreById(int id)
        {
            var genre = await _genreService.GetGenreById(id);
            if (genre == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(genre);
        }
        [HttpPost("creategenre")]
        public async Task<IActionResult> CreateGenre(string genreName)
        {
            var createGenre = await _genreService.InputGenres(genreName);
            if (createGenre == null)
            {
                return BadRequest("Genre by this name already exists");
            }
            return Ok("Genre has been added  Successfully");

        }
        [HttpPut("updategenre/{id}/{genreName}")]
        public async Task<IActionResult> UpdateGenre(int id, string genreName)
        {
            var genre = new GenreDTO { GenreName = genreName, Id = id };
            var data = await _genreService.UpdateGenres(genre);
            if (data == null)
            {
                return BadRequest("Genre by  this name already exists");
            }
            return Ok("Genre has been changed successfully");

        }
        [HttpDelete("deletegenre/{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteGenre(id);
            return Ok();
        }
    }
}

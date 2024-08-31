using BookStore.DTOs;
using BookStore.Services.AuthorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("getallauthors")]
        public async Task<ActionResult<IEnumerable<AuthorRetrieveDTO>>> GetAllAuthors()
        {
            var data = await _authorService.ViewAllAuthors();
            return Ok(data);
        }
        [HttpGet("getauthorbyid/{id}")]
        public async Task<ActionResult<AuthorRetrieveDTO>> GetAuthorById(int id)
        {
            var data = await _authorService.ViewAuthorById(id);
            if (data != null)
            {
                return Ok(data);   
            }
            return NotFound();
        }
        [HttpPost("uploadauthor")]
        public async Task<IActionResult> UploadAuthor(AuthorDTO author)
        {
            await _authorService.UploadAuthor(author);
            return Ok();
        }
        [HttpPut("updateauthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorDTO author)
        {
            await _authorService.UpdateAuthor(id, author);
            return Ok();
        }
        [HttpDelete("deleteauthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorService(id);
            return Ok();
        }
    }
}

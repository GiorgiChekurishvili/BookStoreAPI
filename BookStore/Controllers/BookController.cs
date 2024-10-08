﻿using BookStore.DTOs.Book;
using BookStore.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        readonly IBookService _bookservice;
        public BookController(IBookService bookService)
        {
            _bookservice = bookService;
        }

        [HttpGet("allbooks")]
        public async Task<ActionResult<IEnumerable<BookRetrieveDTO>>> AllBooks()
        {
            var allbooks = await _bookservice.ViewAllBooks();
            if (allbooks != null)
            {
                return Ok(allbooks);
            }
            return BadRequest();
        }

        [HttpGet("getbookbyid/{id}")]
        public async Task<ActionResult<BookRetrieveDTO>> GetBookById(int id)
        {
            var book = await _bookservice.ViewBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("uploadbook")]
        public async Task<IActionResult> UploadBook(BookUploadUpdateDTO bookUploadUpdateDTO)
        {
            var bookupload = await _bookservice.UploadBook(bookUploadUpdateDTO);
            if (bookupload != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updatebook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookUploadUpdateDTO bookUploadUpdateDTO)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var data = await _bookservice.UpdateBook(id, bookUploadUpdateDTO);
            return Ok();

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deletebook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            await _bookservice.DeleteBookService(id);
            return Ok();
        }
    }
}

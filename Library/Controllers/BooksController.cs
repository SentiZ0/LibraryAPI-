using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using Library.Services.Interfaces;
using Library.Services.Models;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            return await _bookService.GetAllBooksAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(long id)
        {
            var book = await _bookService.GetSingleBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, BookDto book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookService.ModifyBookAsync(book);

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(BookDto book)
        {           
            var newBookId = await _bookService.AddBookAsync(book);
            book.Id = newBookId;

            return CreatedAtAction(nameof(GetBook), new { id = newBookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _bookService.GetSingleBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookService.DeleteBookAsync(book);

            return NoContent();
        }
    }
}

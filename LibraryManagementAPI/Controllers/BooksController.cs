using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(_bookRepository.GetAllBooks());
        }

        [HttpGet("{title}")]
        public ActionResult<Book> GetBookByTitle(string title)
        {
            Book book = _bookRepository.GetBookByTitle(title);
            if (book == null)
            {
                return NotFound(new { Message = "No book found with the given title." });
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book newBook)
        {
            if (_bookRepository.GetBookByISBN(newBook.ISBN) != null)
            {
                return Conflict(new { Message = "A book with the same ISBN already exists." });
            }

            _bookRepository.AddBook(newBook);
            return CreatedAtAction(nameof(GetBookByTitle), new { title = newBook.Title }, newBook);
        }

        [HttpPut("{isbn}")]
        public ActionResult UpdateBook(string isbn, [FromBody] Book updatedBook)
        {
            if (_bookRepository.GetBookByISBN(isbn) == null)
            {
                return NotFound(new { Message = "No book found with the given ISBN." });
            }

            _bookRepository.UpdateBook(isbn, updatedBook);
            return NoContent();
        }

        [HttpDelete("{isbn}")]
        public ActionResult RemoveBook(string isbn)
        {
            if (_bookRepository.GetBookByISBN(isbn) == null)
            {
                return NotFound(new { Message = "No book found with the given ISBN." });
            }

            _bookRepository.RemoveBook(isbn);
            return NoContent();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Services;
using WebApi.Data.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;

        }

        [HttpGet("get-all-book")]
        public IActionResult GetAllBooks() 
        {
            var allbooks = _booksService.GetAllBooks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-Id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var Singlebook = _booksService.GetBookById(id);
            return Ok(Singlebook);
        }

        [HttpPost("add-book-with-author")]
        public IActionResult AddBook([FromBody] BookVM book) 
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("Update-book-by-Id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book) 
        {
            var updatedbook = _booksService.UpdateBookById(id, book);
            return Ok(updatedbook);
        }

        [HttpDelete("Delete-book-by-Id/{id}")]
        public IActionResult DeleteBookById(int id) 
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using BooksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("api/Books")]
    public class BooksController : ControllerBase
    {
        private IBookRepository _books;

        public BooksController(IBookRepository books)
        {
            _books = books;
        }

        [HttpGet]
        // GET api/Books
        public async Task<IActionResult> GetAll()
        {
            var books = await _books.GetAll();
            if (books == null) return NoContent();
            return Ok(books);
        }

        // GET api/Books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _books.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/Books
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _books.Add(book);
            Ok();
        }

        // PUT api/Books/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            book.id = id;
            _books.Update(id, book);
            Ok();
        }
        // DELETE api/Books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var x = await _books.Delete(id);
            if (x == false) return NotFound();
            return Ok();
        }
    }
}

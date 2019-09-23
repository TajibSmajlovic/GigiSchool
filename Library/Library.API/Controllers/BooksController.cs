using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        // GET: api/Books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Unit.Books.Get().ToList());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Book book = Unit.Books.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Insert(book);
                Unit.Save();
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Update(book, id);
                Unit.Save();
                return Ok(book);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Book book = Unit.Books.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    Unit.Books.Delete(book);
                    Unit.Save();
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
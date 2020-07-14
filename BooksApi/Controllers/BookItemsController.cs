using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksApi.Models;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookItemsController : ControllerBase
    {
        private readonly BookContext _context;
        private readonly MockBookRepository _mockBookRepository;

        public BookItemsController(BookContext context)
        {
            _context = context;
            _mockBookRepository = new MockBookRepository();
        }
        /// <summary>
        /// Default call when arriving to index.html page. Fetches 
        /// All books (bookItems) if no book item present fetches some mock books.
        /// </summary>
        /// <returns>
        /// A synced list of bookItem elements from db context. Not literally saving to db.
        /// </returns>
        // GET: api/BookItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookItem>>> GetBookItems()
        {
            // if there is no data, add some mock data
            if (_context.BookItems.Count() == 0)
            {
                _context.AddRange(_mockBookRepository.Allbooks);
                _context.SaveChanges();
            }
            return await _context.BookItems.ToListAsync();
        }
        /// <summary>
        /// API call for bookitems with id, used with editing bookItem
        /// </summary>
        /// <param name="id">Id of selected book</param>
        /// <returns> 
        /// returns a book fields on selected book
        /// If not found returns NotFound
        /// </returns>
        // GET: api/BookItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookItem>> GetBookItem(long id)
        {
            var bookItem = await _context.BookItems.FindAsync(id);

            if (bookItem == null)
            {
                return NotFound();
            }

            return bookItem;
        }

        /// <summary>
        /// Is used to update excisting book item. 
        /// </summary>
        /// <param name="id">Id of the existing element</param>
        /// <param name="bookItem">Bookitem that has changed values</param>
        /// <returns>
        /// Returns NoContent if success and NotFound or BadRequest if element or id doesn't exist.
        /// </returns>
        // PUT: api/BookItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookItem(long id, BookItem bookItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (id != bookItem.Id)
                {
                    return BadRequest();
                }

                _context.Entry(bookItem).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookItemExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
        }
        /// <summary>
        /// Is used to create a new item. 
        /// </summary>
        /// <param name="bookItem">Saves created bookitem</param>
        /// <returns>Returns created bookItem</returns>
        // POST: api/BookItems
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookItem>> PostBookItem(BookItem bookItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.BookItems.Add(bookItem);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBookItem), new { id = bookItem.Id }, bookItem);
            }
        }
        /// <summary>
        /// Deletes bookItem with if it exists with the ID.
        /// </summary>
        /// <param name="id">Id of bookItem</param>
        /// <returns>If book item exists retuns bookItem that was deleted and notfound if not exists</returns>
        // DELETE: api/BookItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookItem>> DeleteBookItem(long id)
        {
            var bookItem = await _context.BookItems.FindAsync(id);
            if (bookItem == null)
            {
                return NotFound();
            }

            _context.BookItems.Remove(bookItem);
            await _context.SaveChangesAsync();

            return bookItem;
        }
        /// <summary>
        /// Helper method for Deleting. Check if item exists.
        /// </summary>
        /// <param name="id">Id that needs to be checked.</param>
        /// <returns></returns>
        private bool BookItemExists(long id)
        {
            return _context.BookItems.Any(e => e.Id == id);
        }
    }
}

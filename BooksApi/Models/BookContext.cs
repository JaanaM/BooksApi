using Microsoft.EntityFrameworkCore;

namespace BooksApi.Models
{
    /// <summary>
    /// Create context to handle the data for the books
    /// </summary>
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            :base(options)
        {

        }
        public DbSet<BookItem> BookItems { get; set;}
        


    }

}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class MockBookRepository
    {
        //private readonly IBookItem _bookItems = new MockBookRepository();

        public IEnumerable<BookItem> Allbooks  =>             
            new List<BookItem>
            {
                new BookItem {Id=1, Name ="Harry Potter", Author="J.K Rowling",
                    Description="Fantasy book about young Wizard named Harry Potter..."},
                new BookItem {Id=2, Name= "The Expanse", Author="James S.A. Corey",
                    Description="Scifi book about space, spacechips, politics, aliens and relationships in space"},
                new BookItem {Id=3, Name= "The Little Prince", Author="Antoine de Saint-Exupéry",
                    Description="One of the most popular childrenbooks.." }
            };

       
    }
}

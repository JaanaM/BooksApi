using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class MockBookRepository
    {
        public IEnumerable<BookItem> AllBooks => 
            new List<BookItem>
            {
                new BookItem {Id=1, Name ="Harry Potter", Author="J.K Rowling", Description="Fantasy book about young Wizard named Harry Potter..."},
                new BookItem {Id=2, Name= "The Expance", Author="James S.A. Corey", Description="Scifi book about space, spacechips, politixs, aliens and relationships in space"},
                new BookItem {Id=3, Name= "The Little Pirce", Author="Antoine de Saint-Exupéry", Description="One of the most popular childrenbooks.." }
            };
    
    }
}

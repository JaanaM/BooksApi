using BooksApi.Models;
using BooksApi.Controllers;
using BooksApi.Test;

namespace BooksApi.Tests
{
    public class TestBooksApiController
    {
        TestBookContext _context;
        BookItemsController _controller;
        IBookItem bookItem;
        // Didn't get the tests working properly :/ 
    //    public TestBooksApiController(TestBookContext context, IBookItem bookItem)
    //    {
    //        _context = context;
    //        _controller = new BookItemsController(bookItem);
    //    }
    //    [Fact]
    //    public void GetAllBooks_SouldReturnAllBooks()
    //    {

    //            var items = controller.Get().ToList();
    //            Assert.Equals(3, items.Count);

    //        }
    //        //var controller = new SimpleBookController(testBooks);

    //        //var result = controller.GetAllBooks() as List<Book>;
    //        //Assert.AreEqual(testBooks.Count, result.Count);
    //    }

    //    [Fact]
    //    public async Task GetAllBooksAsync_ShouldReturnAllBooks()
    //        {
    //            //var testBooks = GetTestBooks();
    //            //var controller = new SimpleBookController(testBooks);

    //            //var result = await controller.GetAllBooksAsync() as List<Book>;
    //            //Assert.AreEqual(testBooks.Count, result.Count);
    //        }

    //    [Fact]
    //    public void GetBook_ShouldReturnCorrectBook()
    //        {
    //            //var testBooks = GetTestBooks();
    //            //var controller = new SimpleBookController(testBooks);

    //            //var result = controller.GetBook(4) as OkNegotiatedContentResult<Book>;
    //            //Assert.IsNotNull(result);
    //            //Assert.AreEqual(testBooks[3].Name, result.Content.Name);
    //        }

    //    [Fact]
    //    public async Task GetBookAsync_ShouldReturnCorrectBook()
    //        {
    //            //var testBooks = GetTestBooks();
    //            //var controller = new SimpleBookController(testBooks);

    //            //var result = await controller.GetBookAsync(4) as OkNegotiatedContentResult<Book>;
    //            //Assert.IsNotNull(result);
    //            //Assert.AreEqual(testBooks[3].Name, result.Content.Name);
    //        }

    //    [Fact]
    //    public void GetBook_ShouldNotFindBook()
    //        {
    //            //var controller = new SimpleBookController(GetTestBooks());

    //            //var result = controller.GetBook(999);
    //            //Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    //        }

    //    private List<BookItem> GetTestBooks()
    //    {
    //        List <BookItem> AllBooks = new List<BookItem>  
    //        {
    //            new BookItem {Id=1, Name ="Harry Potter", Author="J.K Rowling", Description="Fantasy book about young Wizard named Harry Potter..."},
    //            new BookItem {Id=2, Name= "The Expance", Author="James S.A. Corey", Description="Scifi book about space, spacechips, politixs, aliens and relationships in space"},
    //            new BookItem {Id=3, Name= "The Little Pirce", Author="Antoine de Saint-Exupéry", Description="One of the most popular childrenbooks.." }
    //        };

    //        return AllBooks;
    //    }
    }
}
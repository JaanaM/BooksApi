using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksApi.Models;
using BooksApi.Controllers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using BooksApi.Test;

namespace BooksApi.Tests
{
    public class TestBooksApiController
    {
        TestBookContext _context;
        BookItemsController _controller;

        public TestBooksApiController(TestBookContext context)
        {
            _context = context;
            _controller = new BookItemsController(_context);
        }
        [Fact]
        public void GetAllBooks_SouldReturnAllBooks()
        {

                var items = controller.Get().ToList();
                Assert.Equals(3, items.Count);

            }
            //var controller = new SimpleProductController(testProducts);

            //var result = controller.GetAllProducts() as List<Product>;
            //Assert.AreEqual(testProducts.Count, result.Count);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
            {
                //var testProducts = GetTestProducts();
                //var controller = new SimpleProductController(testProducts);

                //var result = await controller.GetAllProductsAsync() as List<Product>;
                //Assert.AreEqual(testProducts.Count, result.Count);
            }

        [Fact]
        public void GetProduct_ShouldReturnCorrectProduct()
            {
                //var testProducts = GetTestProducts();
                //var controller = new SimpleProductController(testProducts);

                //var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
                //Assert.IsNotNull(result);
                //Assert.AreEqual(testProducts[3].Name, result.Content.Name);
            }

        [Fact]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
            {
                //var testProducts = GetTestProducts();
                //var controller = new SimpleProductController(testProducts);

                //var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
                //Assert.IsNotNull(result);
                //Assert.AreEqual(testProducts[3].Name, result.Content.Name);
            }

        [Fact]
        public void GetProduct_ShouldNotFindProduct()
            {
                //var controller = new SimpleProductController(GetTestProducts());

                //var result = controller.GetProduct(999);
                //Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }

        private List<BookItem> GetTestBooks()
        {
            List <BookItem> AllBooks = new List<BookItem>  
            {
                new BookItem {Id=1, Name ="Harry Potter", Author="J.K Rowling", Description="Fantasy book about young Wizard named Harry Potter..."},
                new BookItem {Id=2, Name= "The Expance", Author="James S.A. Corey", Description="Scifi book about space, spacechips, politixs, aliens and relationships in space"},
                new BookItem {Id=3, Name= "The Little Pirce", Author="Antoine de Saint-Exupéry", Description="One of the most popular childrenbooks.." }
            };

            return AllBooks;
        }
    }
}
using BooksApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace BooksApi.Test
{
    public class TestBookContext : DbContext
    {
        protected TestBookContext(DbContextOptions<BookContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }
        protected DbContextOptions<BookContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new BookContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var book1 = new BookItem { Id = 1, Name = "Harry Potter", Author = "J.K Rowling", Description = "Fantasy book about young Wizard named Harry Potter..." };
                var book2 = new BookItem { Id = 2, Name = "The Expance", Author = "James S.A. Corey", Description = "Scifi book about space, spacechips, politixs, aliens and relationships in space" };
                var book3 = new BookItem { Id = 3, Name = "The Little Pirce", Author = "Antoine de Saint-Exupéry", Description = "One of the most popular childrenbooks.." };
                context.AddRange(book1, book2, book3);
                context.SaveChanges();
            }
        }
    }
}

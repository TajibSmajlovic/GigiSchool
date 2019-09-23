using Library.DAL;
using System;
using System.Linq;
using Xunit;

namespace Library.Test
{
    public class BookTest
    {
        //public static LibContext context;
        //public static IRepository<Book> books;

        //[Fact(DisplayName = "Before all test")]
        //private static void Asd()
        //{
        //    context = new TestContext();
        //    books = new Repository<Book>(context);

        //    context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();

        //    books.Insert(new Book { Title = "Book 1" });
        //    books.Insert(new Book { Title = "Book 2" });
        //    context.SaveChanges();
        //}

        //[Fact]
        //public void TestBooksCount()
        //{
        //    context = new TestContext();
        //    books = new Repository<Book>(context);

        //    int N = books.Get().Count();

        //    Assert.Equal(3, N);
        //}

        //[Theory(DisplayName = "Testing Get(id) method")]
        //[InlineData(1, "Book 1")]
        //[InlineData(2, "Book 2")]
        //public void TestId(int id, string bookTitle)
        //{
        //    context = new TestContext();
        //    books = new Repository<Book>(context);

        //    Book book = books.Get(id);
        //    Assert.Equal(bookTitle, book.Title);
        //}

        //[Fact(DisplayName = "Test insert")]
        //public void TestInsert()
        //{
        //    context = new TestContext();
        //    books = new Repository<Book>(context);

        //    books.Insert(new Book { Title = "My new book" });
        //    books.Insert(new Book { Title = "My new book2" });
        //    context.SaveChanges();

        //    Assert.Equal(4, books.Get().Count());
        //}

        //[Fact(DisplayName = "Test delete")]
        //public void TestDelete()
        //{
        //    context = new TestContext();
        //    books = new Repository<Book>(context);

        //    books.Delete(3);
        //    context.SaveChanges();

        //    Assert.Equal(3, books.Get().Count());
        //}
    }
}
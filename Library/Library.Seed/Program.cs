using Library.DAL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Seed
{
    internal class Program
    {
        private static ExcelWorksheet rawAuthors;
        private static ExcelWorksheet rawBooks;
        private static ExcelWorksheet rawPublishers;
        private static ExcelWorksheet rawAuthBooks;

        private static Dictionary<int, int> dicAuthors = new Dictionary<int, int>();
        private static Dictionary<int, int> dicBooks = new Dictionary<int, int>();
        private static Dictionary<int, int> dicPublishers = new Dictionary<int, int>();

        private static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"C:\Projects\Library.xlsx");
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorkbook book = package.Workbook;
                rawPublishers = book.Worksheets["Publishers"];
                rawAuthors = book.Worksheets["Authors"];
                rawBooks = book.Worksheets["Books"];
                rawAuthBooks = book.Worksheets["AuthBooks"];

                Console.WriteLine($"Publishers: {rawPublishers.Dimension.Rows} rows.");
                Console.WriteLine($"Authors: {rawAuthors.Dimension.Rows} rows.");
                Console.WriteLine($"Books: {rawBooks.Dimension.Rows} rows.");
                Console.WriteLine($"AuthBooks: {rawAuthBooks.Dimension.Rows} rows.");

                using (UnitOfWork unit = new UnitOfWork())
                {
                    Book b = unit.Books.Get(6);

                    if (b == null)
                    {
                        Console.WriteLine("Podatak ne postoji");
                    }
                    else
                    {
                        unit.Books.Delete(b);
                        unit.Save();

                        Console.WriteLine("Podatak obrisan");
                    }

                    //for (int row = 2; row <= rawPublishers.Dimension.Rows; row++)
                    //{
                    //    int oldId = rawPublishers.readInteger(row, 1);
                    //    Publisher p = new Publisher
                    //    {
                    //        Name = rawPublishers.readString(row, 2),
                    //        Road = rawPublishers.readString(row, 3),
                    //        ZipCode = rawPublishers.readString(row, 4),
                    //        City = rawPublishers.readString(row, 5),
                    //        Country = rawPublishers.readString(row, 6)
                    //    };
                    //    unit.Publishers.Insert(p);
                    //    unit.Save();
                    //    dicPublishers.Add(oldId, p.Id);
                    //}

                    //for (int i = 2; i <= rawAuthors.Dimension.Rows; i++)
                    //{
                    //    int oldId = rawAuthors.readInteger(i, 1);
                    //    Author author = new Author
                    //    {
                    //        Name = rawAuthors.readString(i, 2),
                    //        Image = rawAuthors.readString(i, 3),
                    //        Biography = rawAuthors.readString(i, 4),
                    //        Birthday = rawAuthors.readDate(i, 5),
                    //        Email = rawAuthors.readString(i, 6)
                    //    };
                    //    unit.Authors.Insert(author);
                    //    unit.Save();
                    //    dicAuthors.Add(oldId, author.Id);
                    //}

                    //for (int i = 2; i <= rawBooks.Dimension.Rows; i++)
                    //{
                    //    int oldId = rawBooks.readInteger(i, 1);
                    //    Book newBook = new Book
                    //    {
                    //        Title = rawBooks.readString(i, 2),
                    //        Description = rawBooks.readString(i, 3),
                    //        Image = rawBooks.readString(i, 4),
                    //        Pages = rawBooks.readInteger(i, 5),
                    //        Price = rawBooks.readDecimal(i, 6),
                    //    };
                    //    int oldPublisher = rawBooks.readInteger(i, 7);
                    //    int newPublisher = dicPublishers[oldPublisher];
                    //    newBook.Publisher = unit.Publishers.Get(newPublisher);
                    //    unit.Books.Insert(newBook);
                    //    unit.Save();
                    //    dicBooks.Add(oldId, newBook.Id);
                    //}

                    //for (int i = 2; i <= rawAuthBooks.Dimension.Rows; i++)
                    //{
                    //    int oldAuth = rawAuthBooks.readInteger(i, 2);
                    //    int olBook = rawAuthBooks.readInteger(i, 1);
                    //    AuthBooks authBook = new AuthBooks
                    //    {
                    //        Author = unit.Authors.Get(dicAuthors[oldAuth]),
                    //        Book = unit.Books.Get(dicBooks[olBook])
                    //    };
                    //    unit.AuthBooks.Insert(authBook);
                    //}
                    //unit.Save();
                }
            }
        }
    }
}
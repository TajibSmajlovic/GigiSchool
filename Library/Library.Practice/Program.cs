using Library.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Library.Practice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                int i = 1;
                foreach (Book book in unit.Books.Get().Include(x => x.Publisher).Include(x => x.Authors))
                {
                    // Publisher p = unit.Publishers.Get(book.Publisher.Id);

                    Console.WriteLine($"{i}: {book.Title} ({book.Authors.Count}) published by {book.Publisher.Name}");
                    i++;
                }
            }
        }
    }
}
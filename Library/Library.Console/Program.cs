using Library.DAL;
using System;
using System.Linq;

namespace Library.Con
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (LibContext contex = new LibContext())
            {
                Publisher p = new Publisher();
                Console.WriteLine("Publisher name: ");
                p.Name = Console.ReadLine();
                Console.WriteLine("Address: ");
                p.Road = Console.ReadLine();
                Console.WriteLine("Zip code: ");
                p.ZipCode = Console.ReadLine();
                Console.WriteLine("City: ");
                p.City = Console.ReadLine();
                Console.WriteLine("Country: ");
                p.Country = Console.ReadLine();

                contex.Publishers.Add(p);
                contex.SaveChanges();

                Book b = new Book();
                Console.WriteLine("Book title: ");
                b.Title = Console.ReadLine();
                Console.WriteLine("Book cover: ");
                b.Image = Console.ReadLine();
                Console.WriteLine("Number of pages: ");
                b.Pages = int.Parse(Console.ReadLine());
                Console.WriteLine("Book price: ");
                b.Price = decimal.Parse(Console.ReadLine());
                Console.Write("Publisher: ");
                string pubName = Console.ReadLine();
                Publisher pub = contex.Publishers.FirstOrDefault(x => x.Name == pubName);
                b.Publisher = pub;

                contex.Books.Add(b);

                int n = contex.SaveChanges();
                Console.WriteLine($"{ n } transactions commited.");
            }
        }
    }
}
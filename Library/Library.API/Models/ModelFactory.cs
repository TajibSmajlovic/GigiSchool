using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DAL;

namespace Library.API.Models
{
    public class ModelFactory
    {
        public PublisherModel Create(Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                City = publisher.City,
                Country = publisher.Country,
                ZipCode = publisher.ZipCode,
                Road = publisher.Road,

                Books = publisher.Books.Select(x => new MasterModel { Id = x.Id, Name = x.Title }).ToList()
            };
        }

        public AuthorModel Create(Author author)
        {
            return new AuthorModel
            {
                // Id = author.Id,
                Name = author.Name,
                Image = author.Image,
                Biography = author.Biography,
                Birthday = author.Birthday,
                Email = author.Email,

                Books = author.Books.Select(x => new MasterModel { Id = x.Book.Id, Name = x.Book.Title }).ToList()
            };
        }

        //    public AuthorModel Create(Author author)
        //    {
        //        return new AuthorModel
        //        {
        //            Name:author.name,
        //Image { get; set; },
        // Biography { get; set; },
        // Birthday { get; set; },
        // Email { get; set; },
        //public List<MasterModel> Books { get; set; },

        //Books = publisher.Books.Select(x => new MasterModel { Id = x.Id, Name = x.Title }).ToList()
        //        };
        //    }
        //}
    }
}
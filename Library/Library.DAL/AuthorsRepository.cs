using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DAL
{
    internal class AuthorsRepository : Repository<Author>
    {
        public AuthorsRepository(LibContext context) : base(context)
        {
        }

        public override IQueryable<Author> Get()
        {
            return dbSet.Include(x => x.Books).ThenInclude(x => x.Author);
        }

        //public override Author Get(int id)
        //{
        //    Author author = Get().FirstOrDefault(x => x.Id == id);

        //    return author;
        //}
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DAL
{
    public class BooksRepository : Repository<Book>
    {
        public BooksRepository(LibContext context) : base(context)
        {
        }

        public override IQueryable<Book> Get()
        {
            return dbSet.Include(x => x.Publisher).Include(x => x.Authors);
        }
    }
}
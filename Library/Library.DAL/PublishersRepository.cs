using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DAL
{
    internal class PublishersRepository : Repository<Publisher>
    {
        public PublishersRepository(LibContext context) : base(context)
        {
        }

        public override IQueryable<Publisher> Get()
        {
            return dbSet.Include(x => x.Books).ThenInclude(x => x.Authors).ThenInclude(x => x.Author);
        }

        public override Publisher Get(int id)
        {
            Publisher publisher = Get().FirstOrDefault(x => x.Id == id);

            return publisher;
        }
    }
}
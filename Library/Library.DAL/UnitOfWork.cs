using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public class UnitOfWork : IDisposable
    {
        private LibContext _context = new LibContext();
        private IRepository<Author> _authors;
        private IRepository<Publisher> _publishers;
        private BooksRepository _books;
        private IRepository<AuthBooks> _authbooks;

        public LibContext Context { get { return _context; } }

        public IRepository<Author> Authors
        {
            get
            {
                return _authors ?? (_authors = new Repository<Author>(_context));
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                return _books ?? (_books = new BooksRepository(_context));
            }
        }

        public IRepository<Publisher> Publishers
        {
            get
            {
                return _publishers ?? (_publishers = new PublishersRepository(_context));
            }
        }

        public IRepository<AuthBooks> AuthBooks
        {
            get
            {
                return _authbooks ?? (_authbooks = new Repository<AuthBooks>(_context));
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
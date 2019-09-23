using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DAL
{
    public class LibContext : DbContext
    {
        public LibContext() : base()
        {
        }

        public LibContext(DbContextOptions<LibContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthBooks> AuthBooks { get; set; }

        protected override void OnConfiguring
                   (DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql(
            "User ID=postgres; Password = admin123; Server = localhost; Port = 5432; Database = library; Integrated Security = true; Pooling = true; ");
        }

        protected override void OnModelCreating
                        (ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Author>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Book>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Publisher>().HasQueryFilter(x => !x.Deleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted && x.Entity is BaseClass))
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["Deleted"] = true;
            }

            return base.SaveChanges();
        }
    }
}
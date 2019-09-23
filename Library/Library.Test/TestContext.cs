using Library.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Test
{
    internal class TestContext : LibContext
    {
        protected override void OnConfiguring
                   (DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql(
            "User ID=postgres; Password = admin123; Server = localhost; Port = 5432; Database = testLibrary; Integrated Security = true; Pooling = true; ");
        }
    }
}
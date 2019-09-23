using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DAL
{
    public class AuthBooks : BaseClass
    {
        public int Id { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
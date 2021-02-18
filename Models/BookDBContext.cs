using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    //  inherit from dbcontext
    public class BookDBContext : DbContext
    {
        //  pass dboptions which inherit from base options
        public BookDBContext (DbContextOptions<BookDBContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}

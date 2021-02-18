using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BookDBContext _context;

        public EFBooksRepository (BookDBContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}

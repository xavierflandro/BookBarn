using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    // inherits from iqueryable object
    public class EFBooksRepository : IBooksRepository
    {
        private BookDBContext _context;

        public EFBooksRepository (BookDBContext context)
        {
            //  set private context prop equal to passed context argument
            _context = context;
        }
        //  dynamically assign iqueryable to private context prop
        public IQueryable<Book> Books => _context.Books;
    }
}

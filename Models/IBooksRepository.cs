using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    public interface IBooksRepository
    {
        //  create queryable object of book objects
        IQueryable<Book> Books { get; }
    }
}

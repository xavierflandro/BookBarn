using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        /*ADD*/
        public virtual void AddItem(Book b, int qty)
        {
            //  Set line variable to line from Lines where bookId == passed bookId
            CartLine line = Lines
                .Where(p => p.Book.BookId == b.BookId)
                .FirstOrDefault();

            if (line == null)
            //  If no line found, add new line obj passing book + qty
            {
                Lines.Add(new CartLine
                {
                    Book = b,
                    Quantity = qty
                });
            }
            else
            // set qty on queried line
            {
                line.Quantity += qty;
            }
        }
        /*REMOVE*/
        public virtual void RemoveLine(Book book) => Lines.RemoveAll(x => x.Book.BookId == book.BookId);
        /*CLEAR*/
        public virtual void Clear() => Lines.Clear();
        /*TOTAL*/
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);    


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}

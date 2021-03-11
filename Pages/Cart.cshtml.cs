using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBarn.Infrastructure;
using BookBarn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookBarn.Pages
{
    public class CartModel : PageModel
    {
        private IBooksRepository repository;

        //Constructor
        public CartModel(IBooksRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = ReturnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        //Methods
        public IActionResult OnPost(long bookId, string returnUrl)   //parameters come from hidden fields (should match)
        {
            Book book = repository.Books.FirstOrDefault(predicate => predicate.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("Cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(l =>
                l.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}

using BookBarn.Models;
using BookBarn.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models.ViewModels;

namespace BookBarn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBooksRepository _repository;

        //  sets items per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {
            //  check for validation
            if (ModelState.IsValid)
            {
                return View(new ProjectListViewModel
                {
                    Books = _repository.Books
                        .Where(b => category == null || b.SubCategory == category)  // Filters by either all books when category is null or by books where CategorySec == non-null category
                        .OrderBy(b => b.BookId)                                     // Order by BookId
                        .Skip((page - 1) * PageSize)                                // Skip to third element (element 2)
                        .Take(PageSize)                                             // Set items per page
                    ,
                    // set paging info
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ?                              //  if null, TotalNumItems will equal count of all book else count of books with matching subcategory
                        _repository.Books.Count() :
                        _repository.Books.Where(x => x.SubCategory == category).Count()
                    },
                    CurrentCategory = category          // set current category to first parameter
                }); ;
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

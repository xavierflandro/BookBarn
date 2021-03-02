using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookBarn.Models;

namespace BookBarn.Components
{
    public class SubCategoryMenuViewComponent : ViewComponent       //  inherits from ViewComponent
    {
        private IBooksRepository repository;                        //  defines a property of type IBookRepo

        public SubCategoryMenuViewComponent (IBooksRepository r)    //  instantiates the repository property with passed parameter
        {
            repository = r;
        }

        public IViewComponentResult Invoke()                                //  invoke method returns IViewCompResult object (partial view) called default.cshtml
        {                                                                   //    where the repo's books are selected/orderd by distinct subcategories
            ViewBag.SelectedCategory = RouteData?.Values["category"];    
            return View(repository.Books
                .Select(x => x.SubCategory)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}

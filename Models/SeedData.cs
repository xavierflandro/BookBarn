using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                //  migrate if there are migrations to be made
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                //  add initial book objects to context if none present
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorMiddle = "",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        CategoryPrim = "Fiction",
                        CategorySec = "Classic",
                        NumPages = 1488,
                        Price = 9.95
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Biography",
                        NumPages = 944,
                        Price = 14.58
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorMiddle = "",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Biography",
                        NumPages = 832,
                        Price = 21.54
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C.",
                        AuthorLast = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Biography",
                        NumPages = 864,
                        Price = 11.61
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorMiddle = "",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492 ",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Historical",
                        NumPages = 528,
                        Price = 13.33
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorMiddle = "",
                        AuthorLast = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        CategoryPrim = "Fiction",
                        CategorySec = "Historical Fiction",
                        NumPages = 288,
                        Price = 15.95
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorMiddle = "",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Self-Help",
                        NumPages = 304,
                        Price = 14.99
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorMiddle = "",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Self-Help",
                        NumPages = 240,
                        Price = 21.66
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorMiddle = "",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Business",
                        NumPages = 400,
                        Price = 29.16
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorMiddle = "",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        CategoryPrim = "Fiction",
                        CategorySec = "Thrillers",
                        NumPages = 642,
                        Price = 15.03
                    },

                    new Book
                    {
                        Title = "How To Win Friends and Influence People",
                        AuthorFirst = "Dale",
                        AuthorMiddle = "",
                        AuthorLast = "Carnegie",
                        Publisher = "Simon and Schuster",
                        ISBN = "9781442344815",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Self-Help",
                        NumPages = 291,
                        Price = 11.85
                    },

                    new Book
                    {
                        Title = "Rich Dad Poor Dad",
                        AuthorFirst = "Robert",
                        AuthorMiddle = "T.",
                        AuthorLast = "Kiyosaki",
                        Publisher = "Warner Books Ed",
                        ISBN = "978-1469202167",
                        CategoryPrim = "Non-Fiction",
                        CategorySec = "Business",
                        NumPages = 336,
                        Price = 11.29
                    },

                    new Book
                    {
                        Title = "The Richest Man in Babylon",
                        AuthorFirst = "George",
                        AuthorMiddle = "S.",
                        AuthorLast = "Clason",
                        Publisher = "Penguin Books",
                        ISBN = "978-0451205360",
                        CategoryPrim = "Fiction",
                        CategorySec = "Business",
                        NumPages = 144,
                        Price = 10.95
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
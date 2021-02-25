using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookBarn.Models
{
    public class Book
    {
        //  indicate the primary key
        [Key]
        [Required]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirst { get; set; }

        [Required]
        public string AuthorMiddle { get; set; }

        [Required]
        public string AuthorLast { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required][RegularExpression("^[0-9]{3}-[0-9]{10}$")]
        public string ISBN { get; set; }

        [Required]
        public string CategoryPrim { get; set; }

        [Required]
        public string CategorySec { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int NumPages { get; set; }
    }
}

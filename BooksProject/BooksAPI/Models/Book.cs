using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class Book
    {
        public int? id { get; set; }

        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int? pageCount { get; set; }
        [Required]
        public string excerpt { get; set; }
        [Required]
        public DateTime? publishDate { get; set; }
    }
}

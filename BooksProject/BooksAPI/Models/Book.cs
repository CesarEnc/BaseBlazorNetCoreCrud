using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public string excerpt { get; set; }
        public DateTime publishDate { get; set; }
    }
}

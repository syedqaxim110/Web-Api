using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
       // public string AuthorName { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

        //Navigation Properties
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }
    }
}

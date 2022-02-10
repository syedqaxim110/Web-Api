using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
       
    }

    public class BookWithAuthorsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }

        public string PublisherNames { get; set; }
        public List<string> AuthorNames { get; set; }

    }
}

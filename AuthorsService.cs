using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.ViewModels;

namespace WebApi.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;

        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Fullname = author.Fullname
                
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.Fullname,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }

    }
}

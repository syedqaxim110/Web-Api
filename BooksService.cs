using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.ViewModels;

namespace WebApi.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;

        }
        public void AddBookWithAuthors(BookVM book) 
        {
            var _book = new Book()
            {
                Id = book.Id,
                Title = book.Title,
                Rating = book.Rating,
                Genre = book.Genre,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author() 
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();
        public BookWithAuthorsVM GetBookById(int bookId) 
        {
            var _bookwithauthors = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Id = book.Id,
                Title = book.Title,
                Rating = book.Rating,
                Genre = book.Genre,
                PublisherNames = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.Fullname).ToList()
            }).FirstOrDefault();
            return _bookwithauthors;
        
        
        }

        public Book UpdateBookById(int bookId,BookVM book) 
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                //_book.AuthorName = book.AuthorName;
                _book.Rating = book.Rating;
                _book.Genre = book.Genre;

                _context.SaveChanges();

            }
            
            return _book;
        }

        public void DeleteBookById(int bookId) 
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null) 
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}

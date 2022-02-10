using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Book_Author>().HasOne(b => b.Book).WithMany(ba => ba.Book_Authors).HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<Book_Author>().HasOne(b => b.Author).WithMany(ba => ba.Book_Authors).HasForeignKey(bc => bc.AuthorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any()) 
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Harry Potter and half blood prince",
                        //AuthorName = "J.K.Rowling",
                        Genre = "Magic and Thrill",
                        Rating = 9.0
                    },
                    new Book()
                    {
                        Title = "Harry Potter and Order of the pheonix",
                        //AuthorName = "J.K.Rowling",
                        Genre = "Magic and Thrill",
                        Rating = 8.5
                    }
                    ) ;
                    context.SaveChanges();
                }
            
            }
        }
    }
}

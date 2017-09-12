using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bibliofile.Models;
using Bibliofile.Data;

namespace Bibliofile.Data
{
    public static class DBInitilzer
    {
        public static void Initilizer(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //check DB for any books
                if (context.Books.Any())
                {
                    return; //DB has been seeded
                }

                //Seeder data
                var book = new Books[]
                {
                    new Books{
                        Title = "Post Office", 
                        Author = "Charles Bukowski", 
                        Image = "https://images.gr-assets.com/books/1424999238l/51504.jpg",
                    },
                    new Books{
                        Title="The Autobiography of Gucci Mane",
                        Author="Gucci Mane",
                        Image="https://images.gr-assets.com/books/1501538675m/34623128.jpg",
                    },
                    new Books{
                        Title="The Sun Also Rises", 
                        Author="Ernest Hemingway",
                        Image="https://images.gr-assets.com/books/1331828228l/3876.jpg"
                    }
                };

                var appUser = new ApplicationUser[]
                {
                    new ApplicationUser{
                        FirstName = "Joey",
                        LastName = "Biotti"
                    }
                };

                foreach(Books x in book)
                {
                     context.Add(x);
                     context.SaveChanges();
                }
           
            }
        }
    }
}
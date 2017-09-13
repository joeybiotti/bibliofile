using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bibliofile.Models;
using Bibliofile.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bibliofile.Data
{
    //Built on 9/12. Seeds DB with data for initial testing 
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
                    },
                    new Books{
                        Title= "The Great Gatsby", 
                        Author= "F. Scott Fitzgerald", 
                        Image= "https://images.gr-assets.com/books/1490528560l/4671.jpg"
                    }, 
                    new Books{
                        Title= "The Outsiders", 
                        Author="S.E. Hinton",
                        Image="https://images.gr-assets.com/books/1442129426l/231804.jpg"
                    },
                    new Books{
                        Title="In Cold Blood",
                        Author="Truman Capote",
                        Image="https://images.gr-assets.com/books/1388208531l/9920.jpg"
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
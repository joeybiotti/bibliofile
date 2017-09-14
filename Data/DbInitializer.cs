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
                    },
                    new Books{
                        Title="On The Road",
                        Author="Jack Kerouac",
                        Image="https://images.gr-assets.com/books/1413588576l/70401.jpg"
                    },
                    new Books{
                        Title="Hillbilly Elegy: A Memoir of a Family and Culture in Crisis",
                        Author="J.D. Vance",
                        Image="https://www.goodreads.com/book/show/27161156-hillbilly-elegy"
                    },
                    new Books{
                         Title="The Amazing Adventures of Kavalier & Clay",
                         Author="Michael Chabon",
                         Image="https://images.gr-assets.com/books/1333579505l/12679626.jpg"
                    },
                    new Books{
                         Title="The Catcher in the Rye",
                         Author="J.D. Salinger",
                         Image="https://images.gr-assets.com/books/1398034300l/5107.jpg"
                    },
                    new Books{
                         Title="The Road",
                         Author="Cormac McCarthy",
                         Image="https://images.gr-assets.com/books/1439197219l/6288.jpg"
                    },
                    new Books{
                         Title="Siddhartha",
                         Author="Hermann Hesse",
                         Image="https://images.gr-assets.com/books/1428715580l/52036.jpg"
                    },
                    new Books{
                         Title="The Stranger",
                         Author="Albert Camus",
                         Image="https://images.gr-assets.com/books/1349927872l/49552.jpg"
                    },
                    new Books{
                         Title="The Big Sleep",
                         Author="Raymond Chandler",
                         Image="https://images.gr-assets.com/books/1371584712l/2052.jpg"
                    },
                    new Books{
                         Title="The Killer Inside Me",
                         Author="Jim Thompson",
                         Image="https://images.gr-assets.com/books/1403187402l/298663.jpg"
                    },
                    new Books{
                         Title="On Writing: A Memoir of the Craft",
                         Author="Stephen King",
                         Image="https://images.gr-assets.com/books/1348589692l/7143113.jpg"
                    },
                    new Books{
                         Title="The Elements of Style",
                         Author="William Strunk Jr. and E.B. White",
                         Image="https://images.gr-assets.com/books/1347762378l/3721092.jpg"
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

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using bibliofile.Models;
using bibliofile.Data;

namespace bibliofile.Data
{
    public static class DBInitilzer
    {
        public static void Initilizer(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
            }
        }
    }
}
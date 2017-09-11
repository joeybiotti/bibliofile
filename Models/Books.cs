using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace bibliofile.Models
{
    public class Books
    {
        public int BookId {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public string Summary {get; set;}
    }
}
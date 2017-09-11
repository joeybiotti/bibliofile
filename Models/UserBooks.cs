using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace bibliofile.Models
{
    public class UserBooks
    {
        public int UserId {get; set;}
        public int BookId {get; set;}
        public bool IsRead {get; set;} 
    }
}
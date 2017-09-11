using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace bibliofile.Models
{
    public class Users
    {
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
    }
}
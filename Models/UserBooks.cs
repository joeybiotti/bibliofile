using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace bibliofile.Models
{
    public class UserBooks
    {   
        [Required]
        public ApplicationUser User {get; set;}
        [Required]
        public Books Book {get; set;}
        [Required]
        public bool IsRead {get; set;} 
    }
}
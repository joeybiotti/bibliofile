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
        [Key]
        public int UserBookId {get; set;}
        [Required]
        public ApplicationUser User {get; set;}
        public Books Book {get; set;}
        [Required]
        public bool IsRead {get; set;} 
        [Required]
        public int BookId {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace bibliofile.Models
{
    public class CollectedBooks
    {
        public string CollectedBook {get; set;}
        [Required]
        public int BookId {get; set;}
        public string Author {get; set;}
        public string Summary {get; set;}
        [Required]
        public ApplicationUser User {get; set;}

    }
}
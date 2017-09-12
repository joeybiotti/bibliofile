using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Bibliofile.Models
{
    //Worked on 9/11
    public class CollectedBooks
    {
        [Key]
        public int CollectedBookId {get; set;}
        [Required]
        public Books Book {get; set;}
        public string Author {get; set;}
        public string Summary {get; set;}
        [Required]
        public ApplicationUser User {get; set;}
        public ICollection <CollectedBooks> Books {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Bibliofile.Models
{
    public class Books
    //Worked on 9/11. Added Description 9/18
    {
        [Key]
        public int BookId {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public string Image {get; set;}
        public string Description {get; set;}
        public bool IsRead {get; set;}

    }
}
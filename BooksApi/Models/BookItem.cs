using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class BookItem
    {
        public long Id { get; set; } [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}

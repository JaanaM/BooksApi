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
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Author { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}

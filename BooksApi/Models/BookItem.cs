using System.ComponentModel.DataAnnotations;

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

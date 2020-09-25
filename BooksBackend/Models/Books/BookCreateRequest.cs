using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksBackend.Models.Books
{
    public class BookCreateRequest : IValidatableObject
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Author { get; set; }
        [Range(1, 5000)]
        public int NumberOfPages { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title.ToLower() == "it" && Author.ToLower() == "king")
            {
                yield return new ValidationResult("That book is not allowed.", new string[] { "Title", "Author" });
            }
        }
    }
}

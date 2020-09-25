using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksBackend.Models.Books
{
    public class GetAllBooksResponse
    {
        public List<BooksResponseItem> Data { get; set; }
    }
}

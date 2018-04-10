using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.OData.Builder;

namespace BookService.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        [Contained]
        public IList<Comment> Comments { get; set; }

        public IList<Author> Authors { get; set; }

    }
}

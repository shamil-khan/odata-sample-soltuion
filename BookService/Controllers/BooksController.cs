using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using BookService.Models;

namespace BookService.Controllers
{
    public class BooksController : ODataController
    {
        private static IList<Book> Books = null;

        public BooksController()
        {
            if (Books == null)
            {
                Books = InitializeBooks(10);
            }
        }

        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(Books);
        }

        [EnableQuery]
        public Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var selectedBooks =
                    SingleResult
                    .Create<Book>
                    (Books.Where(book => book.Id == key).AsQueryable());

            return Task.FromResult((IHttpActionResult)Ok(selectedBooks));
        }

        private static IList<Book> InitializeBooks(int count)
        {
            var books = new List<Book>(count);

            for (int i = 1; i <= count; i++)
            {
                var index = 100 * (i-1);
                var book = new Book { Id = i, Title = "Book-"+i, Year = 2000 + i };
                book.Authors = new List<Author>(3);
                book.Authors.Add(new Author { Id = 1 + index, Name = "Author-" + (1 + index) });
                book.Authors.Add(new Author { Id = 2 + index, Name = "Author-" + (2 + index) });
                book.Authors.Add(new Author { Id = 3 + index, Name = "Author-" + (3 + index) });
                book.Comments = new List<Comment>(3);
                book.Comments.Add(new Comment { Id = 1 + index, Text = "Text-" + (1 + index) });
                book.Comments.Add(new Comment { Id = 2 + index, Text = "Text-" + (2 + index) });
                book.Comments.Add(new Comment { Id = 3 + index, Text = "Text-" + (3 + index) });
                books.Add(book);
            }

            return books;
        }
    }
}

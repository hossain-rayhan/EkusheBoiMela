using System.Collections.Generic;
using System.Web.Http;
using EkusheBoiMela.Model;
using System.Linq;

namespace EkusheBoiMela.Controllers
{
    public class BooksController : ApiController
    {
        private  readonly  DataContext _db = new DataContext();
        // GET api/books
        public IEnumerable<BookInfo> Get()
        {
            const string testString = "Hlw AppSomehow";
            var books = new List<BookInfo>();
            var bList = _db.Books.ToList();
            foreach (var book in bList)
            {
                books.Add(new BookInfo{
                    Isbn = book.Isbn,
                    Title = book.Title,
                    TitleInEnglish = book.TitleInEnglish,
                    Author = book.Author.Name,
                    AuthorInEnglish = book.Author.NameInEnglish,
                    Catagory = book.Catagory.Name,
                    Publisher = book.Publisher.Name,
                    PublisherInEnglish = book.Publisher.NameInEnglish,
                    Price = book.Price,
                    Description = book.Description,
                    CoverPhoto = GetBytes(testString),
                    StallNo = book.Publisher.StallNo,
                    StallLat = book.Publisher.StallLat,
                    StallLong = book.Publisher.StallLong,
                    CreationDate = book.CreationDate
                });
            }
            return books;
        }

        private byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}

using BookWebApi.Comunication.Request;
using BookWebApi.Comunication.Response;
using BookWebApi.Entities;
using BookWebApi.Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers
{
    public class BooksController : AppController
    {
        private static List<Book> booksDb = new List<Book>
        {
            new Book {
                Id = 1,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                Description = "The Hobbit is a tale of high adventure, undertaken by a company of dwarves in search of dragon",
                Gender = EnumGender.MISTERY,
                Price = 10.00,
                QuantityStock = 5
            },

            new Book {
                Id = 2,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                Description = "The Hobbit is a tale of high adventure, undertaken by a company of dwarves in search of dragon",
                Gender = EnumGender.ROMANCE,
                Price = 10.00,
                QuantityStock = 5
            },
            new Book {
                Id = 3,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                Description = "The Hobbit is a tale of high adventure, undertaken by a company of dwarves in search of dragon",
                Gender = EnumGender.FICCTION,
                Price = 10.00,
                QuantityStock = 5
            },
        };

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(booksDb);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status201Created)]
        public IActionResult CreateBook([FromBody] RequestBookJson book)
        {
            Book newBook = new Book
            {
                Id = booksDb.Count + 1,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Gender = book.Gender.ToString() ?? string.Empty,
                Price = book.Price,
                QuantityStock = book.QuantityStock
            };


            booksDb.Add(newBook);

            return Created(string.Empty, newBook);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status404NotFound)]
        public IActionResult UpdateBook([FromRoute] int id, [FromBody] RequestBookJson book)
        {
            Book? bookToUpdate = booksDb.FirstOrDefault(x => x.Id == id);

            if (bookToUpdate == null)
                return NotFound();

            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Gender = book.Gender;
            bookToUpdate.Price = book.Price;
            bookToUpdate.QuantityStock = book.QuantityStock;

            return Accepted(book);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook([FromRoute] int id) 
        {
            Book? bookToDelete = booksDb.FirstOrDefault(x => x.Id == id);

            if (bookToDelete == null)
                return NotFound();

            booksDb.Remove(bookToDelete);

            return NoContent();
        }
    }
}

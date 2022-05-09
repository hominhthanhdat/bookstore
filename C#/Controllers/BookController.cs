using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/book")]
    public class BookController : Controller
    {
        private BookService bookService;
        public BookController(BookService _bookService)
        {
            bookService = _bookService;
        }


        //Show data
        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(bookService.GetAll());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //show details data 
        [Produces("application/json")]
        [HttpGet("getbyid/{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                return Ok(bookService.GetById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //tao book moi
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Book book)
        {
            try
            {
                return Ok(new
                {
                    Result = bookService.NewBook(book)
                }) ;
            }
            catch
            {

                return BadRequest();
            }
        }

        //Delete
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    Result = bookService.DeleteBook(id)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        //update

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("update")]
        public IActionResult Update([FromBody] Book book)
        {
            try
            {
                return Ok(new
                {
                    Result = bookService.UpdateBook(book) 
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        //Get n newbook nay ko dc
        [Produces("application/json")]
        [HttpGet("getnewbook/{number}")]
        public IActionResult getNewBook(int number)
        {
            try
            {
                return Ok(bookService.GetNewBook(number));
            }
            catch
            {
                return BadRequest();
            }
        }

        //Get book by author min and max price
        [Produces("application/json")]
        [HttpGet("getbyauthor/{author}/{min}/{max}")]
        public IActionResult getByAuthor(string author,int min , int max)
        {
            try
            {
                return Ok(bookService.GetBookofAuthorInMinMax(author,min,max));
            }
            catch
            {
                return BadRequest();
            }
        }

        // Get book in amount of time
        [Produces("application/json")]
        [HttpGet("getbydate/{start}/{end}")]
        public IActionResult getByDate(string start, string end)
        {
            var startDay = DateTime.ParseExact(start, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            var endDay = DateTime.ParseExact(end, "yyyy-MM-dd",
                                     System.Globalization.CultureInfo.InvariantCulture);
           
            try
            {
                return Ok(bookService.GetBookInAmountTime(startDay, endDay));
            }
            catch
            {
                return BadRequest();
            }
        }
        //get author

 
        [Produces("application/json")]
        [HttpGet("getauthor")]
        public IActionResult getAuthor()
        {
            try
            {
                return Ok(bookService.GetAuthors());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}



using BookStore.Models;

namespace BookStore.Services
{
    public class BookServiceImplement : BookService
    {
        private DatabaseContext db;
        public BookServiceImplement(DatabaseContext _db)
        {
            db = _db;
        }
        public bool DeleteBook(int id)
        {
            try
            {
                db.Books.Remove(db.Books.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
         
        }

        public dynamic GetAll()
        {
            return db.Books.ToList();
        }

        public dynamic GetAuthors()
        {
            return db.Books.Select(x=>x.Author).Distinct().ToList();
        }

        public dynamic GetBookInAmountTime(DateTime start, DateTime end)
        {
            Console.WriteLine(start);
            return db.Books.Where(x => x.Created <= end && x.Created >= start).ToList();    
        }

        public dynamic GetBookofAuthorInMinMax(string author, int min, int max)
        {
           return db.Books.Where(x=>x.Author == author && x.Price >= min && x.Price <= max).ToList();
        }

        public dynamic GetById(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);    
        }

        public dynamic GetNewBook(int number)
        {
            var max = db.Books.Count();
            if(number >= max)
            {
                number = max;
            }
            return db.Books.OrderByDescending(x=>x.Created).ToList().GetRange(0, number);
        }

        public bool NewBook(Book book)
        { 
            try
            {
                db.Books.Add(book);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

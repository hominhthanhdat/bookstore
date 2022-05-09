using BookStore.Models;

namespace BookStore.Services
{
    public interface BookService
    {
        public dynamic GetAll();
        public dynamic GetById(int id);
        public bool NewBook(Book book);
        public bool UpdateBook(Book book);
        public bool DeleteBook(int id);
        public dynamic GetAuthors();
        public dynamic GetNewBook(int number);
        public dynamic GetBookofAuthorInMinMax(string author,int min,int max);
        public dynamic GetBookInAmountTime(DateTime start, DateTime end);
    }
}

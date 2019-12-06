using IDataInterface;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BookManager : IBookManager
    {
        public void AddBook(int bookNumber)
        {
            using var context = new LibraryContext();

            var book = new Book();
            book.BookNumber = bookNumber;

            context.Books.Add(book);
            context.SaveChanges();
        }

        public Book GetBookByBookNumber(int bookNumber)
        {
            using var context = new LibraryContext();
            return (from b in context.Books
                   where b.BookNumber == bookNumber
                   select b).FirstOrDefault();
        }

        public void RemoveBook(int bookID)
        {

            using var context = new LibraryContext();
            var book = (from b in context.Books
                        where b.BookID == bookID
                        select b).FirstOrDefault();
            book.Deleted = true;
            context.SaveChanges();
        }

        public void MoveBook(int bookID, int shelfID)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                         where b.BookID == bookID
                         select b)
                         .First();
            book.ShelfID = shelfID;
            context.SaveChanges();
        }
    }
}

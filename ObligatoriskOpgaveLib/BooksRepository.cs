using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveLib
{
    public class BooksRepository
    {
        private List<Book> books = new();

        public BooksRepository()
        {
            books.Add(new Book() { Id = 1, Title = "Hamlet", Price = 1300});
            books.Add(new Book() { Id = 2, Title = "The Lord of the Rings", Price = 1700});
            books.Add(new Book() { Id = 3, Title = "The Hobbit", Price = 1800});
            books.Add(new Book() { Id = 4, Title = "The Silmarillion", Price = 1900});
            books.Add(new Book() { Id = 5, Title = "The Da Vinci Code", Price = 2000});
        }

        public IEnumerable<Book> Get(string? orderBy = null, string? titlePart = null, int? priceBelow = null)
        {
            IEnumerable<Book> result = new List<Book>(books);
            if (titlePart != null)
            {
                result = result.Where(b => b.Title!.Contains(titlePart));
            }
            if (priceBelow != null)
            {
                result = result.Where(b => b.Price < priceBelow);
            }
            if (orderBy != null)
            {
                result = orderBy switch
                {
                    "Title" => result.OrderBy(b => b.Title),
                    "Price" => result.OrderBy(b => b.Price),
                    _ => throw new ArgumentException("Unknown orderBy value", "orderBy")
                };
            }
            return result;
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public Book? Add(Book book)
        {
            book.ValidateTitle();
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return book;
        }

        public Book? Update(int id, Book book)
        {
           Book? bookToUpdate = GetById(id);
            if (bookToUpdate == null)
            {
                return null;
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Price = book.Price;
            return bookToUpdate;
        }

    }
}

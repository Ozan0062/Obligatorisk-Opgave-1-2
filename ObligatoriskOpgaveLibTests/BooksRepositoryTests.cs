using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpgaveLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpgaveLib.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {

        [TestMethod()]
        public void GetTest()
        {
            BooksRepository booksRepository = new BooksRepository();
            IEnumerable<Book> books = booksRepository.Get();
            Assert.AreEqual(5, books.Count());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            BooksRepository booksRepository = new BooksRepository();
            Book? book = booksRepository.GetById(1);
            Assert.IsNotNull(book);
            Assert.AreEqual("Hamlet", book?.Title);

            Book? book2 = booksRepository.GetById(10);
            Assert.IsNull(book2);
        }

        [TestMethod()]
        public void AddTest()
        {
            BooksRepository booksRepository = new BooksRepository();
            Book? book = new Book() { Title = "The Alchemist", Price = 2000 };
            booksRepository.Add(book);
            IEnumerable<Book> books = booksRepository.Get();
            Assert.AreEqual(6, book.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BooksRepository booksRepository = new BooksRepository();
            Book? book = booksRepository.Delete(1);
            Assert.IsNotNull(book);
            Assert.AreEqual("Hamlet", book.Title);

            IEnumerable<Book> books = booksRepository.Get();
            Assert.AreEqual(4, books.Count());

            Book? book2 = booksRepository.Delete(10);
            Assert.IsNull(book2);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            BooksRepository booksRepository = new BooksRepository();
            Book book = new Book() { Title = "Hamlet", Price = 1800 };
            
            Book? updatedBook = booksRepository.Update(5, book);
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual("Hamlet", updatedBook.Title);
            Assert.AreEqual(1800, updatedBook.Price);

            Book? updatedBook2 = booksRepository.Update(10, book);
            Assert.IsNull(updatedBook2);
        }
    }
}
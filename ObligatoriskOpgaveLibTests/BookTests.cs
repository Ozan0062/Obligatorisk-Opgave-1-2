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
    public class BookTests
    {
        [TestMethod()]
        public void ValidateTitleTest()
        {
           Book hamlet = new Book() {Id = 1, Title = "Hamlet", Price = 1300};
           hamlet.ValidateTitle();

           Book emptyTitle = new Book() { Id = 2, Title = "", Price = 1400};
           Assert.ThrowsException<ArgumentException>(() => emptyTitle.ValidateTitle());

           Book nullTitle = new Book() { Id = 3, Title = null, Price = 1500};
           Assert.ThrowsException<ArgumentNullException>(() => nullTitle.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            Book theLordOfTheRings = new Book() { Id = 4, Title = "The Lord of the Rings", Price = 1700};
            theLordOfTheRings.ValidatePrice();

            Book negativePrice = new Book() { Id = 5, Title = "The Hobbit", Price = -100};
            Assert.ThrowsException<ArgumentException>(() => negativePrice.ValidatePrice());

            Book tooLowPrice = new Book() { Id = 6, Title = "The Silmarillion", Price = 100};
            Assert.ThrowsException<ArgumentException>(() => tooLowPrice.ValidatePrice());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Book theHobbit = new Book() { Id = 7, Title = "The Hobbit", Price = 1800};
            Assert.AreEqual("Id: 7, Title: The Hobbit, Price: 1800", theHobbit.ToString());
        }
    }
}
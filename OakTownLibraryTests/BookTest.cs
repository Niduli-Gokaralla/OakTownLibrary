using Microsoft.VisualStudio.TestTools.UnitTesting;
using OakTownLibrary;

namespace OakTownLibrary.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void BookConstructorSetAllFields()
        {
            // Arrange
            string title = "Test book";
            string author = "Test author";
            int year = 2023;
            string isbn = "978-1234567890";
            int pages = 300;

            //Act
            var book = new Book(title, author, year, isbn, pages);

            //Assert
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(year,book.YearOfPublication);
            Assert.AreEqual(isbn,book.ISBN);
            Assert.AreEqual(pages,book.NumberOfPages);
            Assert.AreEqual("",book.BorrowedByMemberID);
            Assert.IsTrue(book.IsAvailable);



        }
        [DataTestMethod]
        [DataRow(1,10)]
        [DataRow(5,50)]
        [DataRow(10,100)]
        [DataRow(30,300)]
        [DataRow(0,0)]
        public void BookBorrowingCostTest (int days,int expectedCost)
        {
            var book = new Book("Test","Author",2023,"123",300);

            decimal actualCost = book.CalculateBorrowingCost(days);

            Assert.AreEqual(expectedCost,(int) actualCost);

        }



    }
}
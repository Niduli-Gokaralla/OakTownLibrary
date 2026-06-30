using Microsoft.VisualStudio.TestTools.UnitTesting;
using OakTownLibrary;

namespace OakTownLibrary.Tests
{
    [TestClass]
    public class ReferenceBookTest

    {
        [TestMethod]
        public void ReferenceBookConstructerTest()

        {
            //Arrange
            string title = "Encyclopedia";
            string author = "Various Authors";
            int year = 2023;
            string isbn = "978-1234567890";
            int pages = 1500;
            bool isRestricted = true;

            //Act
            var refBook = new ReferenceBook(title, author, year, isbn, pages, isRestricted);

            //Asserts
            Assert.AreEqual(title, refBook.Title);
            Assert.AreEqual(author, refBook.Author);
            Assert.AreEqual(year, refBook.YearOfPublication);
            Assert.AreEqual(isbn, refBook.ISBN);
            Assert.AreEqual(pages, refBook.NumberOfPages);
            Assert.AreEqual(isRestricted, refBook.IsRestricted);
            Assert.AreEqual("", refBook.BorrowedByMemberID);
            Assert.IsTrue(refBook.IsAvailable);

        }
        [TestMethod]
        public void ReferenceBookRestrictedTest()
        {
            //Act
            var refBook = new ReferenceBook("Test", "Author", 2023, "123", 500, true);

            //Assert
            Assert.IsTrue(refBook.IsRestricted);
        
        }

        [TestMethod]
        public void ReferenceBookInheritanceTest()
        {
            //Act
            var refBook = new ReferenceBook("Test", "Author", 2023, "123", 500, true);

            //Assert
            Assert.IsInstanceOfType(refBook, typeof(Book));
            Assert.IsInstanceOfType(refBook, typeof(LibraryItem));
            Assert.AreEqual(500, refBook.NumberOfPages);
        }
                

    }
}

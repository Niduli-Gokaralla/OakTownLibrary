using Microsoft.VisualStudio.TestTools.UnitTesting;
using OakTownLibrary;

namespace OakTownLibrary.Tests
{
    [TestClass]
    public class LibraryTest

    {
        private Library library;
        [TestInitialize]
        public void Setup()
        {
            library = new Library();
        }

        [TestMethod]
        public void SearchByTitleTest()

        {
            //ACT
            var results = library.SearchByTitle("Great");

            //Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Great Gatsby", results[0].Title);
        }

        [TestMethod]
        public void SearchByISBNTest()
        {
            //Act
            var result = library.SearchByIsbn("978-0060935467");

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("To Kill a Mockingbird", result.Title);
            Assert.AreEqual("Harper Lee", result.Author);


        }
    }
}

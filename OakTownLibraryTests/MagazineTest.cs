using Microsoft.VisualStudio.TestTools.UnitTesting;
using OakTownLibrary;

namespace OakTownLibrary.Tests
{
    [TestClass]
    public class MagazineTest

    {
        [TestMethod]
        public void MagazineConstructerTest()

        {
            //Arrange
            string title = "National ";
            string author = "Various ";
            int year = 2023;
            string isbn = "ISSN-0027-9358";
            int issueNumber = 245;

            //Act
            var magazine = new Magazine(title, author, year, isbn, issueNumber);

            //Asserts
            Assert.AreEqual(title, magazine.Title);
            Assert.AreEqual(author, magazine.Author);
            Assert.AreEqual(year, magazine.YearOfPublication);
            Assert.AreEqual(isbn, magazine.ISBN);
            Assert.AreEqual(issueNumber, magazine.IssueNumber);
            Assert.AreEqual("", magazine.BorrowedByMemberID);
            Assert.IsTrue(magazine.IsAvailable);

        }

        [DataTestMethod]
        [DataRow(1, 5)]
        [DataRow(3, 15)]
        [DataRow(7, 35)]
        [DataRow(10, 50)]
        [DataRow(0, 0)]
        public void MagazineBorrowingCostTest(int days, int expectedCost)
        {
            var magazine = new Magazine("Test", "Publisher", 2023, "ISSN-123", 1);

            decimal actualCost = magazine.CalculateBorrowingCost(days);

            Assert.AreEqual(expectedCost, (int)actualCost);

        }
    }
}
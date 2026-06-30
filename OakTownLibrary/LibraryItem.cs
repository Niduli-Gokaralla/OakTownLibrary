using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    public abstract class LibraryItem
    {
        public string Title {  get; set; }
        public string Author { get; set; }
        public int YearOfPublication { get; set; }
        public string ISBN {  get;set; }
        public string BorrowedByMemberID { get; set; } = "";

        public bool IsAvailable=>string.IsNullOrEmpty(BorrowedByMemberID);


        //Constructor
        public LibraryItem(string title,string author,int year,string isbn)
        {
            Title = title;
            Author = author;
            YearOfPublication = year;
            ISBN = isbn;
            BorrowedByMemberID = "";
        }
        public override string ToString()
        {
            string status;
            if (IsAvailable)
                status = "Available";
            else
                status =$"Borrowed by {BorrowedByMemberID}";

            return $"{Title} by {Author} ({YearOfPublication}) - ISBN{ISBN} - {status}";


        }
        public abstract decimal CalculateBorrowingCost(int days);
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    public class Book : LibraryItem
    {
        public int NumberOfPages {  get; set; }

        public Book (string title,string author,int year,string isbn,int numPages):base(title,author,year,isbn)
        { 
            NumberOfPages = numPages;
        }

        public override string ToString()
        {
            string details=base.ToString();
            return $"{details} -{NumberOfPages} pages";
        }

        public override decimal CalculateBorrowingCost(int days)
        {
            return days*10m;
        }
    }
}

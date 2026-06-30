using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    public class ReferenceBook:Book
    {
        public bool IsRestricted {  get; set; }

        public ReferenceBook(string title, string author, int year, string isbn, int numPages, bool isRestricted) : base(title, author, year, isbn, numPages)
        {
            IsRestricted = isRestricted;
        }
        public override string ToString()
        {
            string restrictionStatus = IsRestricted ? "Restricted" : "Not Restricted";
            return $"{base.ToString()}-{restrictionStatus}";
            
        }

        //Reference books cannot be borrowed
        public override decimal CalculateBorrowingCost(int days)
        {
            return 0;
        }
    }

}

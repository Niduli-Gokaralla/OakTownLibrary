using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber {  get; set; }

        public Magazine(string title, string author, int year, string isbn,int issueNum) : base(title,author,year,isbn)
        {
            IssueNumber = issueNum;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Issue #{IssueNumber}";
        }

        public override decimal CalculateBorrowingCost(int days)
        {
            return days * 5m;
        }
    }
}

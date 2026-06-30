using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    public class Member
    {
        public string MemberID {  get; set; }
        public List<LibraryItem> CurrentlyBorrowed {  get; set; }
        public List<LibraryItem>PreviouslyBorrowed { get; set; }

        public Member(string memberID)
            { 
                MemberID = memberID; 
                CurrentlyBorrowed = new List<LibraryItem>();
                PreviouslyBorrowed=new List<LibraryItem>();
            }

        public void BorrowItem(LibraryItem item)
        {
            CurrentlyBorrowed.Add(item);
            item.BorrowedByMemberID = MemberID;
        }

        public void ReturnItem(LibraryItem item)
        {
            if (CurrentlyBorrowed.Contains(item)) 
            {
                CurrentlyBorrowed.Remove(item);
                PreviouslyBorrowed.Add(item);
                item.BorrowedByMemberID = "";
            }

        }
    }
}

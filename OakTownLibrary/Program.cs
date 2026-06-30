using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    internal class Program
        
    {
        private static Library library = new Library();
        private static Member currentMember=new Member("M123");
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                try
                {

                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine("\n Welcome To The Oak Town Library Management System ");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine("1. List all library items");
                    Console.WriteLine("2. Search available items by title keyword");
                    Console.WriteLine("3. Borrow an item ");
                    Console.WriteLine("4. Return an item");
                    Console.WriteLine("5. Calculate borrowing cost");
                    Console.WriteLine("6. List currently borrowed items");
                    Console.WriteLine("7. List previously borrowed items");
                    Console.Write    ("Enter your choice (or -1 to exit): ");
                    string choice = Console.ReadLine();

                    if (choice == "-1")
                    {
                        exit = true;
                        Console.WriteLine("You are exiting the system... Good Bye!");
                        continue;

                    }


                    switch (choice)
                    {
                        case "1":
                            ListAllItems();
                            break;

                        case "2":
                            SearchItems();
                            break;

                        case "3":
                            BorrowItems();
                            break;

                        case "4":
                            ReturnItems();
                            break;

                        case "5":
                            CalculateCost();
                            break;

                        case "6":
                            ListOfCurrentBorrowings();
                            break;

                        case "7":
                            ListOfPreviousBorrowings();
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please Try Again");
                            break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalied input.Please enter a valid number.");
                }

                if (!exit)
                {
                    Console.WriteLine("\n Press enter to continue");
                    Console.ReadLine();
                }

            }
        }

        private static void ListAllItems()
        {
            Console.WriteLine("\n All library items");
            Console.WriteLine(new string('-', 40));
            if (library.Items.Count == 0)
            {
                Console.WriteLine("No items in the library");
                return;
            }
            foreach (var item in library.Items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void SearchItems()
        {
            Console.Write("Enter title to search : ");
            string keyword = Console.ReadLine();

            var results = library.SearchByTitle(keyword);

            Console.WriteLine($"\n --- Available Items Matching {keyword}---");
            if (results.Count == 0)
            {
                Console.WriteLine("No available items match with your search");
                return;
            }
            foreach (var item in results)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private static void BorrowItems()
        {
            try
            {
                Console.Write("Enter ISBN of the item to borrow : ");
                string isbn = Console.ReadLine();

                LibraryItem item = library.SearchByIsbn(isbn);

                if (item == null)
                {
                    Console.WriteLine("Item not found ");
                }
                else if (!item.IsAvailable)
                {
                    Console.WriteLine("Item is already borrowed");
                }
                else if (item is ReferenceBook referenceBook && referenceBook.IsRestricted)
                {
                    Console.WriteLine("Cannot borrow restricted reference book");
                }
                else
                {
                    currentMember.BorrowItem(item);
                    Console.WriteLine($"Successfully Borrowed : {item.Title}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while borrowing. Please try again.");
            }
        }

        private static void ReturnItems()
        {
            try
            {
                Console.Write("Enter ISBN of the item that you want to return : ");
                string isbn = Console.ReadLine();

                LibraryItem item = library.SearchByIsbn(isbn);

                if (item == null)
                {
                    Console.WriteLine("Item not found");
                }
                else if (item.IsAvailable || item.BorrowedByMemberID != currentMember.MemberID)
                {
                    Console.WriteLine("This item was not borrowed by you");
                }

                else
                {
                    currentMember.ReturnItem(item);
                    Console.WriteLine($"Successfully returned: {item.Title}");
                }
            }
            catch
            {
                Console.WriteLine("An error occurred while returning the item. Please try again.");
            }
        }

        private static void CalculateCost()
        {
            try
            {
                Console.Write("Enter ISBN of the item : ");
                string isbn = Console.ReadLine();

                LibraryItem item = library.SearchByIsbn(isbn);

                if (item == null)
                {
                    Console.WriteLine("Item not found");
                    return;
                }

                Console.Write("Enter number of days : ");
                if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
                {
                    Console.WriteLine("Invalid number of days");
                    return;
                }

                decimal cost = item.CalculateBorrowingCost(days);
                Console.WriteLine($"Borrowing cost for {days} days: Rs.{cost:F2}");

            }
            catch
            {
                Console.WriteLine("An error occurred while calculating the borrowing cost. Please try again.");
            }
        }
        private static void ListOfCurrentBorrowings()
        {
           Console.WriteLine("\n --- Currently Borrowed Items ---");
           if (currentMember.CurrentlyBorrowed.Count == 0)
                {
                  Console.WriteLine("No items currently borrowed");
                  return;
                }

           foreach (var item in currentMember.CurrentlyBorrowed)
                {
                  Console.WriteLine(item.ToString());
                }
        }

        private static void ListOfPreviousBorrowings()
        {
            Console.WriteLine("\n ---Previously Borrowed Items---");
            if (currentMember.PreviouslyBorrowed.Count == 0)
            {
                Console.WriteLine("No items previously borrowed");
                return;

            }

            foreach (var item in currentMember.PreviouslyBorrowed)

            {
               Console.WriteLine(item.ToString());
            }
        }
    }
                    
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakTownLibrary
{
    public class Library
    {
        public List<LibraryItem> Items { get; set; }

        public Library()
        {
            Items = new List<LibraryItem>();
            AddingSampleData();
        }

        private void AddingSampleData()
        {   //Books
            Items.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960, "978-0060935467", 281)); 
            Items.Add(new Book("1984", "George Orwell", 1949, "978-0451524935", 328));
            Items.Add(new Book("Pride and Prejudice", "Jane Austen", 1813, "978-0141439518", 432));
            Items.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565", 180));
            Items.Add(new Book("Moby Dick", "Herman Melville", 1851, "978-1503280786", 635));

            //Reference Book
            Items.Add(new ReferenceBook("Encyclopedia Britannica", "Various", 2020, "978-1593392925", 1000, true));
            Items.Add(new ReferenceBook("Oxford English Dictionary", "Oxford University Press", 2018, "978-0199573158", 3500, true));
            Items.Add(new ReferenceBook("Gray's Anatomy", "Henry Gray", 2021, "978-0702077050", 1600, false));

            //Magazine
            Items.Add(new Magazine("National Geographic", "Various", 2023, "ISSN-0027-9358", 245));
            Items.Add(new Magazine("Time", "Various", 2023, "ISSN-0040-781X", 12));
            Items.Add(new Magazine("Science", "AAAS", 2023, "ISSN-0036-8075", 45));
            Items.Add(new Magazine("Forbes", "Various", 2023, "ISSN-0015-6914", 30));

        }
        public List<LibraryItem>SearchByTitle(string keyword)
        {
            List<LibraryItem> results = new List<LibraryItem>();
            foreach (var item in Items)
            {
                if (item.Title.ToLower().Contains(keyword.ToLower()) && item.IsAvailable)
                {
                    results.Add(item);
                }
           
            }
            return results;

        }

        public LibraryItem SearchByIsbn(string isbn)
        {
            foreach (LibraryItem item in Items)
            {
                if (item.ISBN.ToLower()==(isbn.ToLower()))
                    {
                        return item;
                    }
            }

            return null;
        }

    }
    
}

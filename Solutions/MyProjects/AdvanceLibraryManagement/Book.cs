
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvanceLibraryManagement
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
        public User Borrower { get; set; }

        public Book()
        {

        }

        public Book(string title, string author, string isbn, string genre)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Genre = genre;
        }
    }
}

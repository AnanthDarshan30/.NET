using FileLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvanceLibraryManagement
{
    public class User : IUser 
    {
        public string Name { get; set; }
        public List<Book> borrowedBooks;
        private Library library;

        public User(string name)
        {
            Name = name;
            borrowedBooks = new List<Book>();
        }

        public bool BorrowBook(Library library, string isbn)
        {
            if (library.BorrowBook(this, isbn)) return true;
            else return false;
        }

        public bool ReturnBook(Library library, string isbn)
        {
            if(library.ReturnBook(this, isbn)) return true;
            else return false;
        }

        public List<Book> GetBorrowedBooks()
        {
            return borrowedBooks;
        }
    }
}

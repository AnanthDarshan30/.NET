using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileLogger;

namespace AdvanceLibraryManagement
{
    public class Library
    {
        private ConcurrentDictionary<string, Book> books = new ConcurrentDictionary<string, Book>();
        private readonly object bookLock = new object();
        public bool AddBook(Book book)
        {
            return books.TryAdd(book.ISBN, book);
        }

        public bool RemoveBook(string isbn)//exception
        {
            return books.TryRemove(isbn, out _);
        }

        public void SearchBooks(string searchTerm)
        {
            var results = books.Values
                          .Where(book => (searchTerm.ToLower().Equals("available") && book.IsAvailable) ||
                           (searchTerm.ToLower().Equals("unavailable") && !book.IsAvailable) ||
                           (!string.IsNullOrEmpty(book.Genre) && book.Genre.ToLower().Contains(searchTerm.ToLower())) ||
                           (book.Title.ToLower().Contains(searchTerm.ToLower()) ) ||
                           (book.Author.ToLower().Contains(searchTerm.ToLower())) ||
                          (book.ISBN.ToLower().Contains(searchTerm.ToLower()) ));
            //// not handle ddat

            Console.WriteLine($"Search results for '{searchTerm}':");
            if (!results.Any())
            {
                Console.WriteLine("No matching books found.");
            }
            foreach (var book in results)
            {
                Console.WriteLine($"    - ISBN: {book.ISBN}, {book.Title} by {book.Author} (Availability Status: {book.IsAvailable})");
            }
        }

        public bool BorrowBook(User user,string isbn)
        {
            if (books.TryGetValue(isbn, out var book))
            {
                lock (bookLock)
                {
                    if (!book.IsAvailable)
                    {
                        Logger.Debug($"The book '{book.Title}' is currently unavailable.");
                        Console.WriteLine($"The book '{book.Title}' is currently unavailable.");
                        return false;
                    }
                    user.borrowedBooks.Add(book);
                    book.IsAvailable = false;
                    book.Borrower = user;
                    

                    Logger.Debug($"{user.Name} borrowed '{book.Title}' with ISBN {isbn}");
                    return true;
                }
            }
            else
            {
                Logger.Warning($"Book with ISBN {isbn} was not found.");
                return false;
            }

        }

        public List<Book> GetAvailableBooks()
        {
            return books.Values.Where(book => book.IsAvailable).ToList();
        }

        public List<Book> GetBorrowedBooksByUser(User user)
        {
            return user.GetBorrowedBooks();
        }

        public bool ReturnBook(User user, string isbn)
        {
            lock(bookLock)
            {
                if(books.TryGetValue(isbn,out var book) && !book.IsAvailable)
                {
                    if (book.Borrower == user)
                    {
                        user.borrowedBooks.Remove(book);
                        book.IsAvailable = true;
                        book.Borrower = null;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"You cannot return '{book.Title}' because it was borrowed by {book.Borrower.Name}.");
                        return false;
                    }

                }
                else
                {

                    Console.WriteLine($"You cannot return '{book?.Title}' because it was borrowed by {book?.Borrower.Name}.");
                    Logger.Debug($"You cannot return '{book?.Title}' because it was borrowed by {book?.Borrower.Name}.");
                }
                return false;
            }
        }
        public Library()
        {
            InitializeDefaultBooks();
        }
        public void InitializeDefaultBooks()
        {
            AddBook(new Book()
            {
                Title = "Trulu Devious",
                ISBN = "978-0062338068",
                Author = "Maureen Johnson",
                Genre = "Fiction"

            });
            AddBook(new Book(title: "The Risk", "Abby S.T", isbn: "979-8212555555", "Fiction"));
            AddBook(new Book("They Both Die at the End", "Adam Silvera", "978-1471166204", "Fiction"));
            AddBook(new Book("Holding Up The Universe", "Jennifer Niven", "978-0141357058","Fiction"));
            AddBook(new Book("Reckless", "Sidney Sheldon", "978-0008146849","Fiction"));
            AddBook(new Book("The Power of Your Subconscious Mind", "Joseph Murphy", "978-8194790839","Non-Fiction"));
            AddBook(new Book("The Merchant of Venice", "William Shakespeare", "978-9380816296", "Fiction"));
            AddBook(new Book("The Theory of Everything", "Stephen W Hawking", "978-8179925911", "Non-Fiction"));
            Logger.Debug("Default Books are present in the Library");
        }
    }
}

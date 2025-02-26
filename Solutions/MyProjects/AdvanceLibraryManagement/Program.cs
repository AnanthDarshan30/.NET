using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileLogger;
using ExtensionLibrary;

namespace AdvanceLibraryManagement
{
    public class Program
    {
        static User GetUserByName(string userName, List<User> users)
        {
            User selectedUser = users.FirstOrDefault(user => user.Name.ToLower() == userName);
            if (selectedUser != null)
            {
                return selectedUser;
            }
            else
            {
                Logger.Warning("Invalid User Login.");
                Console.WriteLine("Invalid user. Please enter the right username.");
                return null;
            }
        }

        static async Task Main(string[] args)
        {
            Library library = new Library();

            // Prompt user to enter the number of users
            Console.Write("Enter the number of users: ");
            int numberOfUsers;
            while (!int.TryParse(Console.ReadLine(), out numberOfUsers) || numberOfUsers <= 0)
            {
                Console.Write("Please enter a valid positive number for users: ");
            }

            List<User> users = new List<User>();

            // Dynamically add users based on input
            for (int i = 1; i <= numberOfUsers; i++)
            {
                Console.Write($"Enter the name of user{i}: ");
                string name = Console.ReadLine();
                users.Add(new User(name));
            }

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nLibrary Management System:");
                Console.WriteLine("1. Display Available Books");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Search Books");
                Console.WriteLine("5. View Borrowed Books by User");
                Console.WriteLine("6. Add Book");
                Console.WriteLine("7. Remove Book");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Available Books:");
                        Task.Run(() => DisplayAvailableBooks(library)).Wait();
                        break;

                    case "2":
                        Console.Write("Enter ISBN of the book to borrow: ");
                        string isbnBorrow = Console.ReadLine();
                        Console.Write($"Enter User Name: ");
                        string userChoiceBorrow = Console.ReadLine().ToLower();
                        User selectedUserBorrow = GetUserByName(userChoiceBorrow, users);

                        if (selectedUserBorrow != null)
                        {
                            var task1 = Task.Run(() => BorrowBook(library, selectedUserBorrow, isbnBorrow));
                            await task1;
                        }
                        break;

                    case "3":
                        Console.Write("Enter ISBN of the book to return: ");
                        string isbnReturn = Console.ReadLine();
                        Console.Write($"Enter User Name: ");
                        string userChoiceReturn = Console.ReadLine().ToLower();
                        User selectedUserReturn = GetUserByName(userChoiceReturn, users);

                        if (selectedUserReturn != null)
                        {
                            var task2 = Task.Run(() => ReturnBook(library, selectedUserReturn, isbnReturn));
                            await task2;
                        }
                        break;

                    case "4":
                        Console.Write("Enter search term (available/unavailable or title/author/genre): ");
                        string searchTerm = Console.ReadLine();

                        var task3 = Task.Run(() => library.SearchBooks(searchTerm));
                        await task3;
                        break;

                    case "5":
                        Console.Write($"Enter User Name: ");
                        string userChoiceView = Console.ReadLine().ToLower();
                        User selectedUserView = GetUserByName(userChoiceView, users);

                        if (selectedUserView != null)
                        {
                            var task4 = Task.Run(() => DisplayBorrowedBooks(selectedUserView));
                            await task4;
                        }
                        break;

                    case "6":
                        Console.Write("Enter the Title of the Book to add: ");
                        string title = Console.ReadLine().ToParaCase();
                        Console.Write("Enter the Author of the Book to add: ");
                        string author = Console.ReadLine().ToParaCase();
                        Console.Write("Enter the Genre of the Book to add: ");
                        string genre = Console.ReadLine().ToParaCase();
                        Console.Write("Enter the ISBN of the Book to add: ");
                        string isbn = Console.ReadLine().ToParaCase();
                        Book book = new Book(title, author, isbn, genre);

                        bool result = await Task.Run(() => library.AddBook(book));

                        if (result)
                        {
                            Console.WriteLine($"{book.Title} was successfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Could not add the book.");
                        }

                        break;

                    case "7":
                        Console.Write("Enter the ISBN of the book to remove: ");
                        string isbnRemove = Console.ReadLine();
                        bool resultRemove = await Task.Run(() => library.RemoveBook(isbnRemove));
                        if (resultRemove)
                        {
                            Console.WriteLine($"The book was removed.");
                        }
                        else
                        {
                            Console.WriteLine("No such book present in the Library.");
                        }
                        break;

                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        static void BorrowBook(Library library, User user, string isbn)
        {
            if (user.BorrowBook(library, isbn))
            {
                Logger.Debug($"{user.Name} successfully borrowed the book with ISBN {isbn}.");
                Console.WriteLine($"{user.Name} successfully borrowed the book with ISBN {isbn}.");
            }
        }

        static void ReturnBook(Library library, User user, string isbn)
        {
            if (user.ReturnBook(library, isbn))
            {
                Logger.Debug($"{user.Name} successfully returned the book with ISBN {isbn}.");
                Console.WriteLine($"{user.Name} successfully returned the book with ISBN {isbn}.");
            }
            else
            {
                Logger.Debug($"The book with ISBN {isbn} could not be returned or is already available.");
                Console.WriteLine($"The book with ISBN {isbn} could not be returned or is already available.");
            }
        }

        static void DisplayAvailableBooks(Library library)
        {
            var availableBooks = library.GetAvailableBooks();
            if (availableBooks.Count > 0)
            {
                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}");
                }
            }
            else
            {
                Console.WriteLine("No books are currently available.");
            }
        }

        static void DisplayBorrowedBooks(User user)
        {
            var borrowedBooks = user.GetBorrowedBooks();
            if (borrowedBooks.Count > 0)
            {
                foreach (var book in borrowedBooks)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Author: {book.Author}");
                }
            }
            else
            {
                Console.WriteLine($"{user.Name} has not borrowed any books.");
            }
        }
    }
}

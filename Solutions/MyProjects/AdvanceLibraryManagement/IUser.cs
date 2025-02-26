using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvanceLibraryManagement
{
    public interface IUser
    {
        bool BorrowBook(Library library, string isbn);
        bool ReturnBook(Library library, string isbn);
        List<Book> GetBorrowedBooks();
    }
}

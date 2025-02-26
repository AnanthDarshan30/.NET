using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdvanceLibraryManagement
{
    public class BookUnavailableException : Exception
    {
        public BookUnavailableException() : base("The book is currently unavailable.") { }

        public BookUnavailableException(string message) : base(message) { }

        public BookUnavailableException(string message, Exception inner) : base(message, inner) { }
    }
}

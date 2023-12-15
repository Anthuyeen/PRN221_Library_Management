using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Management_FA23_BL5.Logics
{
    internal class BookManager
    {
        public static Book? GetBook(int bookId)
        {
            using var context = new LibraryManagementContext();
            return context.Books.FirstOrDefault(x => x.BookId == bookId);
        }
    }
}

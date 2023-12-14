using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Management_FA23_BL5.Logics
{
    internal class LibrarianManager
    {
        public static List<Librarian> GetLibrarians()
        {
            using var context = new LibraryManagementContext();
            return context.Librarians.ToList();
        }

        public static Librarian? GetLibrarian(int librarianId)
        {
            using var context = new LibraryManagementContext();
            return context.Librarians.FirstOrDefault(x => x.LibrarianId == librarianId);
        }

        public static void AddLibrarian(Librarian data)
        {
            using var context = new LibraryManagementContext();
            context.Librarians.Add(data);
            context.SaveChanges();
        }

        public static void UpdateLibrarian(Librarian data)
        {
            using var context = new LibraryManagementContext();
            context.Librarians.Update(data);
            context.SaveChanges();
        }

        public static void DeleteLibrarian(Librarian data)
        {
            using var context = new LibraryManagementContext();
            context.Librarians.Remove(data);
            context.SaveChanges();
        }
    }
}

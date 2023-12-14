using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Management_FA23_BL5.Logics
{
    internal class AccountManagement
    {
        public static List<Account> GetAccounts()
        {
            using var context = new LibraryManagementContext();
            return context.Accounts.ToList();
        }

        public static Account? GetAccount(string account, string password)
        {
            using var context = new LibraryManagementContext();
            return context.Accounts
                .FirstOrDefault(x =>
                x.Username.Equals(account) &&
                x.Password.Equals(password));
        }

        public static Account? GetAccount(int id)
        {
            using var context = new LibraryManagementContext();
            return context.Accounts.FirstOrDefault(x => x.LibrarianId == id);
        }

        public static Account? GetAccount(string searchString)
        {
            using var context = new LibraryManagementContext();
            if (MailAddress.TryCreate(searchString, out _))
            {
                return context.Accounts.FirstOrDefault(x => x.Gmail.Equals(searchString));
            }
            else
            {
                return context.Accounts.FirstOrDefault(x => x.Username.Equals(searchString));
            }
        }

        public static void UpdateAccount(Account data)
        {
            using var context = new LibraryManagementContext();
            context.Accounts.Update(data);
            context.SaveChanges();
        }
    }
}

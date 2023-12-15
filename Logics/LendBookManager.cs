using Microsoft.EntityFrameworkCore;
using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Management_FA23_BL5.Logics
{
    internal class LendBookManager
    {
        public static List<LendBookDetail> GetLendBookDetails()
        {
            using var context = new LibraryManagementContext();
            return context.LendBookDetails.Include(x => x.Books).ToList();
        }

        public static LendBookDetail? GetLendBookDetail(int ticketId)
        {
            using var context = new LibraryManagementContext();
            return context.LendBookDetails.Include(x => x.Books).FirstOrDefault(x => x.LendBookDetailId == ticketId);
        }

        public static void AddLendBook(LendBookDetail data, Book lendBook)
        {
            using var context = new LibraryManagementContext();
            BookInfo? bookInfo = BookInfoManager.GetBookInfo(lendBook.TitleId);
            if (bookInfo != null)
            {
                bookInfo.InStock -= 1;
                BookInfoManager.UpdateBookInfo(bookInfo);

                data.Books.Add(lendBook);
                context.LendBookDetails.Attach(data).State = EntityState.Added;
            }
            lendBook.Condition = 3;
            context.Books.Update(lendBook);
            context.SaveChanges();
        }
    }
}

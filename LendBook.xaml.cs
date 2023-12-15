using Project_Library_Management_FA23_BL5.Models;
using Project_Library_Management_FA23_BL5.Logics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Project_Library_Management_FA23_BL5.Models;

namespace Project_Library_Management_FA23_BL5
{
    /// <summary>
    /// Interaction logic for LendBook.xaml
    /// </summary>
    public partial class LendBook : Page
    {
        public LendBook()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            try
            {
                using (var context = new LibraryManagementContext())
                {
                    var data = context.Readers.ToList();
                    lv_Reader.ItemsSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                using (var context = new LibraryManagementContext())
                {
                    //var data = context.BookInfos.Include(x => x.Books).ToList();
                    var data = context.Books.Include(x => x.Title).ToList();
                    lv_BookInfo.ItemsSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private readonly int _librarianId;
        private readonly Librarian admin = MainWindow.admin;

        private void btn_CreateTicker_Click(object sender, RoutedEventArgs e)
        {
            string bookId = txt_BookId.Text.Trim();
            string readerId = txt_ReaderId.Text.Trim();

            if (string.IsNullOrEmpty(bookId) || string.IsNullOrEmpty(readerId))
            {
                MessageBox.Show("Please select a reader and a book from the list!");
                return;
            }
            else
            {
                using (var context = new LibraryManagementContext())
                {
                    LendBookDetail lendBook = new LendBookDetail()
                    {
                        CardNumber = Convert.ToInt32(readerId),
                        LibrarianId = admin.LibrarianId,
                        LendDate = DateTime.Now,
                        ExpectedReturnDate = (DateTime)expect.SelectedDate,
                        ReturnCondition = 1,
                    };
                    context.LendBookDetails.Add(lendBook);
                    context.SaveChanges();
                    MessageBox.Show("Create ticket successfully!");
                    Load();
                }







                //    Book? bookToLend = BookManager.GetBook(Convert.ToInt32(bookId));
                //    if (bookToLend != null)
                //    {
                //        LendBookManager.AddLendBook(new()
                //        {
                //            CardNumber = Convert.ToInt32(readerId),
                //            LibrarianId = _librarianId,
                //            LendDate = DateTime.Now,
                //            ExpectedReturnDate = (DateTime)expect.SelectedDate,
                //            ReturnCondition = bookToLend.Condition
                //        }, bookToLend);

                //        MessageBox.Show("Create ticket successfully!");
                //        Load();
                //    }
            }
        }
    }
}

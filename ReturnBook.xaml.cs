using Microsoft.EntityFrameworkCore;
using Project_Library_Management_FA23_BL5.Models;
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
using Project_Library_Management_FA23_BL5.Models;
namespace Project_Library_Management_FA23_BL5
{
    /// <summary>
    /// Interaction logic for ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : Page
    {
        public ReturnBook()
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
                    var query = from r in context.ReturnBooks
                                join lb in context.LendBookDetails on r.LibrarianId equals lb.LibrarianId
                                join read in context.Readers on r.CardNumber equals read.CardNumber
                                //join bid in context.Books on lb.LendBookDetailId equals bid.ReturnBookDetails
                                select new
                                {
                                   // BookId = r.LibrarianName,
                                    ReturnId = r.ReturnId,
                                    CardNumber = r.CardNumber,
                                    FullName = read.FullName,
                                    LibrarianId = lb.LibrarianId,
                                    LendDate = lb.LendDate,
                                    ExpectedReturnDate = lb.ExpectedReturnDate,
                                    ReturnCondition = lb.ReturnCondition,
                                };

                    // In kết quả
                    lv_ReturnBook.ItemsSource = query.ToList();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

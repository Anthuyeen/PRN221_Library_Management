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
                    var data = context.ReturnBooks.ToList();
                    lv_ReturnBook.ItemsSource = data;
                }
                using (var context = new LibraryManagementContext())
                {
                    var data = context.Readers.ToList();
                    lv_ReturnBook.ItemsSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

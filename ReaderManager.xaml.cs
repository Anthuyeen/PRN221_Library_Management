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
    /// Interaction logic for ReaderManager.xaml
    /// </summary>
    public partial class ReaderManager : Page
    {
        public LibraryManagementContext context;
        public ReaderManager()
        {
            context = new LibraryManagementContext();
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
                    listReader.ItemsSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Reader GetReader()
        {
            Reader reader = null;
            try
            {

                reader = new Reader()
                {
                    //Id = int.Parse(txtEmployeeID.Text),
                    CardNumber = int.Parse(txtCardNumber.Text),
                    FullName = txtFullName.Text,
                    DateOfBirth = (DateTime)txtDob.SelectedDate,
                    CardCreationDate = (DateTime)txtCcd.SelectedDate,
                    Address = txtAddress.Text,
                    Occupation = txtOccupation.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return reader;
        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

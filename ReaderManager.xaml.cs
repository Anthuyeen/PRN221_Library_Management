using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
        private Reader? _currentReader;

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
            Load(); 
            txtOccupation.Text = "";
            txtCardNumber.Text = "";
            txtFullName.Text = "";
            txtDob.SelectedDate = null;
            txtCcd.SelectedDate = null;
            txtAddress.Text = "";
            txtCardNumber.Text = "";
            rd_ReaderCard.IsChecked = false;
            rd_ReaderName.IsChecked = false;
            txtSearchBox.Text = "";
        }
       
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (var context = new LibraryManagementContext())
            //    {
            //        var inf = GetReader();
            //        if (inf != null)
            //        {
            //            context.Readers.Add(inf);
            //            context.SaveChanges();
            //            Load();
            //            MessageBox.Show("Insert Reader completed", "Add Reader");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Insert Reader Wrong " + ex.Message, " Add Reader");
            //}

            string occupation = txtOccupation.SelectedIndex switch
            {
               
                0 => "Học Viên",
                1 => "Sinh Viên",
                2 => "Giáo Viên",
                _ => "Error"
            };

            string fullName = txtFullName.Text.Trim();
            DateTime dateOfBirth = (DateTime)txtDob.SelectedDate;
            DateTime cardCreation = DateTime.Now;
            string address = txtAddress.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Reader name and address must not be empty!");
                return;
            }

            ReaderManager.AddReader(new()
            {
                Occupation = occupation,
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                CardCreationDate = cardCreation,
                Address = address,
            });
            MessageBox.Show("Add new reader successfully!");
            Load();
        }
        public static void AddReader(Reader data)
        {
            using var context = new LibraryManagementContext();
            context.Readers.Add(data);
            context.SaveChanges();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new LibraryManagementContext())
            {
                try
                {
                    var inf = GetReader();
                    if (inf != null)
                    {
                        var oldInfor = context.Readers.FirstOrDefault(c => c.CardNumber == inf.CardNumber);
                        if (oldInfor != null)
                        {
                            oldInfor.Occupation = txtOccupation.Text;
                            oldInfor.CardNumber = int.Parse(txtCardNumber.Text);
                            oldInfor.FullName = txtFullName.Text;
                            oldInfor.DateOfBirth = (DateTime)txtDob.SelectedDate;
                            oldInfor.CardCreationDate= (DateTime)txtCcd.SelectedDate;
                            oldInfor.Address = txtAddress.Text;
                            context.Readers.Update(oldInfor);
                            context.SaveChanges();
                            Load();
                            MessageBox.Show("Update Reader completed", "Update Reader");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Reader Wrong" + ex.Message, "Update Reader");
                }
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new LibraryManagementContext())
            {
                try
                {
                    var inf = GetReader();
                    if (inf != null)
                    {
                        var oldInfor = context.Readers.FirstOrDefault(c => c.CardNumber == inf.CardNumber);
                        if (oldInfor != null)
                        {
                            context.Readers.Remove(oldInfor);
                            context.SaveChanges();
                            Load();
                            MessageBox.Show("Delete Reader completed", "Delete Reader");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Reader Wrong" + ex.Message, "Delete Reader");
                }
            }
        }
        /// <summary>
        /// ////////////
        /// </summary>
        private List<Reader> _readers = new();

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public static List<Reader> GetReaders()
        {
            using var context = new LibraryManagementContext();
            return context.Readers.ToList();
        }
    }
}

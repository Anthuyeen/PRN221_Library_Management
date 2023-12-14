using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Project_Library_Management_FA23_BL5.Logics;
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
    /// Interaction logic for AccountManager.xaml
    /// </summary>
    public partial class AccountManager : Page
    {
            public LibraryManagementContext _context;
            public AccountManager()
            {
                InitializeComponent();
                Load();
                this.listView.SelectionChanged += ListView_SelectionChanged;
                _context = new LibraryManagementContext();

            }
            public void RefreshListView()
            {
                Load();
            }
            void Load()
            {
                using (var dbContext = new LibraryManagementContext())
                {
                    // Sử dụng LINQ để kết hợp đơn hàng và khách hàng dựa trên CustomerId
                    //var query = from librarian in dbContext.Librarians
                    //            join account in dbContext.Accounts on librarian.LibrarianId equals account.LibrarianId
                    //            select new
                    //            {
                    //              LibrarianName = librarian.LibrarianName,
                    //              LibrarianId = librarian.LibrarianId,
                    //              Gmail = account.Gmail,
                    //              Username = account.Username,
                    //              Password = account.Password,
                    //            };

                    //// In kết quả
                    //listView.ItemsSource = query.ToList();


                }
                using (var context = new LibraryManagementContext())
                {
                    listView.ItemsSource = context.Accounts.Include(x => x.Librarian).ToList();
                }
            }

            private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                ListView? listView = sender as ListView;
                GridView? gridView = listView != null ? listView.View as GridView : null;

                var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

                var column1 = 0.1;
                var column2 = 0.2;
                var column3 = 0.2;
                var column4 = 0.2;
                var column5 = 0.2;


                if (gridView != null && width >= 0)
                {
                    gridView.Columns[0].Width = width * column1;
                    gridView.Columns[1].Width = width * column2;
                    gridView.Columns[2].Width = width * column3;
                    gridView.Columns[3].Width = width * column4;
                    gridView.Columns[4].Width = width * column5;

                }
            }


            private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                int count = listView.SelectedItems.Count;
                if (count > 0)
                {
                    btnEdit.IsEnabled = true;
                    btnDelete.IsEnabled = true;
                }
                else
                {
                    btnEdit.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                }
            }
            private void Button_Search(object sender, RoutedEventArgs e)
            {
                using (var context = new LibraryManagementContext())
                {
                    List<Account> accounts = context.Accounts.Include(x => x.Librarian).ToList();
                    string UserName = searchByCompanyName.Text;
                    string Gmail = searchByEmail.Text;
                    string LibrarianName = searchByName.Text;
                    if (searchById.Text == "")
                    {
                        listView.ItemsSource = accounts.Where(x => x.Librarian.LibrarianName.Contains(LibrarianName)).Where(x => x.Username.Contains(UserName)).Where(x => x.Gmail.Contains(Gmail));
                        //listView.ItemsSource = context.Accounts.Include(x => x.Librarian).Where(x => x.Username.Contains(UserName)).Where(x => x.Gmail.Contains(Gmail)).ToList();
                    }
                    else
                    {
                        int id = int.Parse(searchById.Text);
                        listView.ItemsSource = accounts.Where(x => x.LibrarianId == id).Where(x => x.Librarian.LibrarianName.Contains(LibrarianName)).Where(x => x.Username.Contains(UserName)).Where(x => x.Gmail.Contains(Gmail));
                    }

                }
            }

            private void Button_OpenCreate(object sender, RoutedEventArgs e)
            {


                AdminMemberCreate adminMemberCreatee = new AdminMemberCreate(this, null);
                adminMemberCreatee.Show();
            }

            private void Button_Reload(object sender, RoutedEventArgs e)
            {
                Load();
            }



            private void Button_Delete(object sender, RoutedEventArgs e)
            {
                var result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (listView.SelectedItem != null)
                    {
                        // Lấy dữ liệu của cột mong muốn từ đối tượng được chọn
                        var selectedData = (Account)listView.SelectedItem;
                        var column1Value = selectedData.LibrarianId;
                        using (var context = new LibraryManagementContext())
                        {
                            var li = context.Accounts.FirstOrDefault(x => x.LibrarianId == column1Value);
                            context.Accounts.Remove(li);
                            context.SaveChanges();
                            MessageBox.Show("Successfully");
                            Load();

                        }
                        // Sử dụng giá trị của cột, bạn có thể thực hiện các hành động khác tùy thuộc vào nhu cầu của bạn

                    }
                }





            }

            private void Button_Edit(object sender, RoutedEventArgs e)
            {
                if (listView.SelectedItem != null)
                {
                    // Lấy dữ liệu của cột mong muốn từ đối tượng được chọn
                    var selectedData = (Account)listView.SelectedItem;
                    var column1Value = selectedData.LibrarianId;
                    using (var context = new LibraryManagementContext())
                    {
                        var li = context.Accounts.Include(x => x.Librarian).FirstOrDefault(x => x.LibrarianId == column1Value);

                        AdminMemberCreate adminMemberCreate = new AdminMemberCreate(this, li);
                        adminMemberCreate.Show();
                    }
                    // Sử dụng giá trị của cột, bạn có thể thực hiện các hành động khác tùy thuộc vào nhu cầu của bạn

                }
            }

        }
    }

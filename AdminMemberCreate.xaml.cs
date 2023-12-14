//using Project_Library_Management_FA23_BL5.Models;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Metrics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using System.Xml.Linq;

//namespace Project_Library_Management_FA23_BL5
//{
//    /// <summary>
//    /// Interaction logic for AdminMemberCreate.xaml
//    /// </summary>
//    public partial class AdminMemberCreate : Window
//    {
//        private readonly AccountManager adminMember;
//        private Account? member;
//        public AdminMemberCreate(AccountManager _adminMember, Account? _member)
//        {
//            InitializeComponent();
//            this.adminMember = _adminMember;
//            this.member = _member;
//        }
//        if(member != null)

//            txtBoxEmail.Text = member.Gmail;
//            txtBoxUserName.Text = member.Username;
//            txtName.Text = member.Librarian.LibrarianName;
//            txtBoxPassword.Text = member.Password;
//            txtBoxId.Text = member.LibrarianId.ToString();
//            txtBoxId.Visibility = Visibility.Visible;
//            labelId.Visibility = Visibility.Visible;
//            btn.Content = "Update";

//    public void GetInfor()
//        {
//            try
//            {
//                using (var context = new LibraryManagementContext())
//                {
//                    Librarian librarian = new Librarian()
//                    {
//                        LibrarianName = txtName.Text,
//                    };
//                    context.Librarians.Add(librarian);
//                    context.SaveChanges(); // Lưu thay đổi để có LibrarianId

//                    Account acc = new Account()
//                    {
//                        Username = txtBoxUserName.Text,
//                        Password = txtBoxPassword.Text,
//                        Gmail = txtBoxEmail.Text,
//                        LibrarianId = librarian.LibrarianId
//                    };

//                    if (member == null)
//                    {
//                        context.Accounts.Add(acc);
//                        context.SaveChanges();
//                    }
//                    else
//                    {
//                        context.Accounts.Update(acc);
//                        context.Librarians.Update(librarian);
//                        context.SaveChanges();
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }


//        }
//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            GetInfor();
//            this.Close();
//            adminMember.RefreshListView();
//        }
//    }
//}
using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Project_Library_Management_FA23_BL5
{
    /// <summary>
    /// Interaction logic for AdminMemberCreate.xaml
    /// </summary>
    public partial class AdminMemberCreate : Window
    {
        private readonly AccountManager adminMember;
        private Account? member;
        public AdminMemberCreate(AccountManager _adminMember, Account? _member)
        {
            InitializeComponent();
            this.adminMember = _adminMember;
            this.member = _member;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (member != null)
            {
                txtBoxEmail.Text = member.Gmail;
                txtBoxUserName.Text = member.Username;
                txtName.Text = member.Librarian.LibrarianName;
                txtBoxPassword.Password = member.Password;
                txtBoxId.Text = member.LibrarianId.ToString();
                txtBoxId.Visibility = Visibility.Visible;
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
            }
        }
        public void GetInfor()
        {
            try
            {
                using (var context = new LibraryManagementContext())
                {
                    Librarian librarian = new Librarian()
                    {
                        LibrarianName = txtName.Text,
                    };
                    context.Librarians.Add(librarian);
                    context.SaveChanges(); // Lưu thay đổi để có LibrarianId

                    Account acc = new Account()
                    {
                        Username = txtBoxUserName.Text,
                        Password = txtBoxPassword.Password,
                        Gmail = txtBoxEmail.Text,
                        LibrarianId = librarian.LibrarianId
                    };

                    if (member == null)
                    {
                        context.Accounts.Add(acc);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Accounts.Update(acc);
                        context.Librarians.Update(librarian);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetInfor();
            this.Close();
            adminMember.RefreshListView();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = txtBoxPassword.Password;
            txtBoxPassword.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBoxPassword.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            txtBoxPassword.Visibility = Visibility.Visible;
        }
    }
}




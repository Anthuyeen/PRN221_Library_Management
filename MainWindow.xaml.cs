using Project_Library_Management_FA23_BL5.Logics;
using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateTime toDay = DateTime.Now;
            lbDay.Content = toDay.ToString("dd/MM/yyyy");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string account = tbAccount.Text.Trim();
            string password = tbPassword.Password.Trim();
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
                MessageBox.Show("Please enter both username and password!");

            Account? login = AccountManagement.GetAccount(account, password);
            if (login != null)
            {
                Librarian? librarian = LibrarianManager.GetLibrarian(login.LibrarianId);
                if (librarian != null)
                {
                    Home home = new(login, librarian);
                    home.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Error in getting librarian info, please check the database!", "Weird Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Wrong account or password!", "Login Failed", MessageBoxButton.OK);
                tbPassword.Password = "";
                tbAccount.Focus();
            }
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Close?", "Exit", MessageBoxButton.YesNoCancel);
            if(result == MessageBoxResult.Yes)
            this.Close();
        }

        private void Chbx_ShowPwd_Checked(object sender, RoutedEventArgs e)
        {
            //tbPassword.PasswordChar = '\0';
            passwordTxtBox.Text = tbPassword.Password;
            tbPassword.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void Chbx_ShowPwd_Unchecked(object sender, RoutedEventArgs e)
        {
            //tbPassword.PasswordChar = '•';
            tbPassword.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            tbPassword.Visibility = Visibility.Visible;
        }
    }
}

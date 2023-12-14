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
using System.Windows.Shapes;

namespace Project_Library_Management_FA23_BL5
{
    /// <summary>
    /// Interaction logic for BookCreate.xaml
    /// </summary>
    public partial class BookCreate : Window
    {
        private readonly int _titleId;
        public BookCreate(int titleId)
        {
            InitializeComponent();
            _titleId = titleId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int quantity = Convert.ToInt32(txtBookQuantity.Text);
            if (quantity > 0)
            {
                MessageBoxResult result = MessageBox.Show($"Do you want to add {quantity} book(s) to this title?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using var context = new LibraryManagementContext();
                    BookInfo? temp = context.BookInfos.FirstOrDefault(x => x.TitleId == _titleId);
                    if (temp != null)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            context.Books.Add(new()
                            {
                                TitleId = _titleId,
                                Condition = 1
                            });
                        }
                        temp.InStock += quantity;
                        context.BookInfos.Update(temp);
                    }
                    context.SaveChanges();
                    MessageBox.Show("Book(s) added successfully!", "Success", MessageBoxButton.OK);
                    Close();
                }
            }
            else if (quantity < 0)
            {
                MessageBox.Show("Please enter a positive number!", "Warning", MessageBoxButton.OK);
                txtBookQuantity.Text = "";
                txtBookQuantity.Focus();
            }

        }

        private void txtNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Loại bỏ ký tự không phải số
            }
        }

        private void txtNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Chặn các phím không phải số như phím chữ, dấu cách, các phím điều hướng, v.v.
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.Back && e.Key != Key.Delete && e.Key != Key.Left && e.Key != Key.Right)
                    {
                        e.Handled = true; // Chặn phím không phải số
                    }
                }
            }
        }
    }
}

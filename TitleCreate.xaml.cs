using Project_Library_Management_FA23_BL5.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TitleCreate.xaml
    /// </summary>
    public partial class TitleCreate : Window
    {
        public TitleCreate()
        {
            InitializeComponent();
            LoadComboBox();
            cbAuthor.SelectedIndex = 0;
            cbPublisher.SelectedIndex = 0;
        }

        public TitleCreate(int titleId)
        {
            InitializeComponent();
            LoadComboBox();
            using var context = new LibraryManagementContext();
            BookInfo? currentBookTitle = context.BookInfos.FirstOrDefault(t => t.TitleId == titleId);
            AuthorBook? authorBook = context.AuthorBooks.FirstOrDefault(t => t.TitleId == titleId);
            txtId.Text = titleId.ToString();

            if (currentBookTitle == null)
            {
                MessageBox.Show("Can't get title info!", "Error", MessageBoxButton.OK);
                Close();
            }
            else
            {
                txtTitle.Text = currentBookTitle.Title;
                txtNumberOfPage.Text = currentBookTitle.NumberOfPages.ToString();

                if (authorBook != null)
                {
                    cbAuthor.SelectedValue = authorBook.AuthorId;
                }
                else
                {
                    cbAuthor.SelectedIndex = 0;
                }

                cbPublisher.SelectedValue = currentBookTitle.PublisherId;

                btn.Content = "Update";
            }
        }

        public void LoadComboBox()
        {
            using (var context = new LibraryManagementContext())
            {
                var authors = new ObservableCollection<Author>(context.Authors.ToList());
                cbAuthor.ItemsSource = authors;

                var publishers = new ObservableCollection<Publisher>(context.Publishers.ToList());
                cbPublisher.ItemsSource = publishers;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            int numberOfPages = Convert.ToInt32(txtNumberOfPage.Text);
            switch (btn.Content)
            {
                case "Create":

                    bool validCheckAdd = CheckTitleAndPages(title, numberOfPages);
                    if (!validCheckAdd) return;
                    AddTitleToBookInfo(title, numberOfPages);
                    AddToAuthorBook(title);
                    break;

                case "Update":
                    bool validCheckEdit = CheckTitleAndPages(title, numberOfPages);
                    if (!validCheckEdit) return;
                    EditTitleBookInfo(txtId.Text);
                    break;
            }
        }

        public void AddTitleToBookInfo(string title, int pages)
        {
            using var context = new LibraryManagementContext();
            int publisherId = Convert.ToInt32(cbPublisher.SelectedValue);

            BookInfo? duplicate = context.BookInfos.FirstOrDefault(x => x.Title.ToUpper() == title.ToUpper());

            if (duplicate != null)
            {
                MessageBox.Show("Title already existed!", "Warning", MessageBoxButton.OK);
                txtTitle.Text = "";
                txtTitle.Focus();
                return;
            }

            context.BookInfos.Add(new()
            {
                Title = title,
                InStock = 0,
                NumberOfPages = pages,
                PublisherId = publisherId,
            });
            context.SaveChanges();
        }

        public void AddToAuthorBook(string title)
        {
            using var context = new LibraryManagementContext();
            int authorId = Convert.ToInt32(cbAuthor.SelectedValue);

            BookInfo? newlyAdded = context.BookInfos.FirstOrDefault(x => x.Title.ToUpper() == title.ToUpper());
            if (newlyAdded == null)
            {
                MessageBox.Show("Add title failed! Please check the database!", "Warning", MessageBoxButton.OK);
                return;
            }
            else
            {
                context.AuthorBooks.Add(new()
                {
                    AuthorId = authorId,
                    TitleId = newlyAdded.TitleId,
                    AuthorRole = "Chủ biên"
                });
                context.SaveChanges();
                MessageBox.Show("Added Successfully!", "Success", MessageBoxButton.OK);
                Close();
            }
        }

        public void EditTitleBookInfo(string titleId)
        {
            using var context = new LibraryManagementContext();
            BookInfo? tempBookInfo = context.BookInfos.FirstOrDefault(t => t.TitleId == Convert.ToInt32(titleId));
            if (tempBookInfo == null)
            {
                MessageBox.Show("Edit title failed! Please check the database!", "Warning", MessageBoxButton.OK);
                return;
            }
            else
            {
                tempBookInfo.Title = txtTitle.Text;
                tempBookInfo.NumberOfPages = Convert.ToInt32(txtNumberOfPage.Text);
                tempBookInfo.PublisherId = (int)cbPublisher.SelectedValue;
                context.BookInfos.Update(tempBookInfo);
                context.SaveChanges();


                AuthorBook? tempAuthorBook = context.AuthorBooks.FirstOrDefault(x => x.TitleId == Convert.ToInt32(titleId));
                if (tempAuthorBook != null)
                {
                    context.AuthorBooks.Remove(tempAuthorBook);
                    context.SaveChanges();

                    tempAuthorBook.AuthorId = (int)cbAuthor.SelectedValue;
                    context.AuthorBooks.Add(tempAuthorBook);
                    context.SaveChanges();
                }

                MessageBox.Show("Updated Successfully!", "Success", MessageBoxButton.OK);

                Close();
            }
        }

        public bool CheckTitleAndPages(string title, int pages)
        {
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Title must not be empty!", "Warning", MessageBoxButton.OK);
                txtTitle.Focus();
                return false;
            }
            else if (pages == 0)
            {
                MessageBox.Show("Invalid number of pages!", "Warning", MessageBoxButton.OK);
                txtNumberOfPage.Focus();
                return false;
            }
            return true;
        }
    }
}

using Project_Library_Management_FA23_BL5.DTOs;
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
    /// Interaction logic for BookManager.xaml
    /// </summary>
    public partial class BookManager : Page
    {
        public BookManager()
        {
            InitializeComponent();
            this.listView.SelectionChanged += ListView_SelectionChanged;
            LoadData();

        }
        List<Book> books;
        List<BookInfo> booksInfo;
        List<Publisher> publishers;
        List<Author> authors;
        List<AuthorBook> authorBooks;
        List<BookManageModel> bookManageModels;
        public static Book? GetBook(int bookId)
        {
            using var context = new LibraryManagementContext();
            return context.Books.FirstOrDefault(x => x.BookId == bookId);
        }
        public void LoadData()
        {
            using var context = new LibraryManagementContext();
            books = context.Books.ToList();
            booksInfo = context.BookInfos.ToList();
            publishers = context.Publishers.ToList();
            authors = context.Authors.ToList();
            authorBooks = context.AuthorBooks.ToList();
            bookManageModels = (from bookInfo in booksInfo
                                join
                                     publisher in publishers on
                                     bookInfo.PublisherId equals publisher.PublisherId
                                join
                                     authorBook in authorBooks on
                                     bookInfo.TitleId equals authorBook.TitleId
                                join
                                     author in authors on
                                     authorBook.AuthorId equals author.AuthorId
                                join
                                     book in books on
                                     bookInfo.TitleId equals book.TitleId
                                     into groupedData
                                from data in groupedData.DefaultIfEmpty()
                                let condition = data?.Condition switch
                                {
                                    1 => "Good",
                                    2 => "Damaged",
                                    3 => "Lent",
                                    _ => "No Data"
                                }
                                select new BookManageModel()
                                {
                                    TitleId = bookInfo.TitleId,
                                    BookId = data?.BookId == null ? "No book in stock" : data.BookId.ToString(),
                                    Title = bookInfo.Title,
                                    Author = author.AuthorName,
                                    Publisher = publisher.PublisherName,
                                    InStock = bookInfo.InStock,
                                    NumberOfPages = bookInfo.NumberOfPages,
                                    Condition = condition,
                                }).ToList();
            listView.ItemsSource = bookManageModels;
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            LoadData();
            DoFilter();

        }

        public void DoFilter()
        {
            string searchString = searchByName.Text;
            RadioButton checkedButton = GetSelectedRadioButton(gbRadioButtons);

            if (checkedButton != null)
            {
                string checkedButtonText = checkedButton.Content?.ToString();

                switch (checkedButtonText)
                {
                    case "Search By Title":
                        listView.ItemsSource = bookManageModels
                            .Where(x => x.Title != null && x.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                            .ToList();
                        break;

                    case "Search By Author":
                        listView.ItemsSource = bookManageModels
                            .Where(x => x.Author != null && x.Author.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                            .ToList();
                        break;

                    default:
                        // Xử lý mặc định hoặc nếu không có lựa chọn nào được chọn
                        listView.ItemsSource = bookManageModels;
                        break;
                }
            }
        }

        public static RadioButton GetSelectedRadioButton(GroupBox groupBox)
        {
            foreach (var radioButton in FindVisualChildren<RadioButton>(groupBox))
            {
                if (radioButton.IsChecked == true)
                {
                    return radioButton;
                }
            }

            return null;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T typedChild)
                    {
                        yield return typedChild;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        public void SetInitialRDAndButton()
        {
            btnDeleteBook.IsEnabled = false;
            btnDeleteTitle.IsEnabled = false;
            btnEditTitle.IsEnabled = false;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = listView.SelectedItems.Count;
            if (count > 0)
            {
                btnDeleteBook.IsEnabled = true;
                btnDeleteTitle.IsEnabled = true;
                btnEditTitle.IsEnabled = true;
                btnAddBook.IsEnabled = true;

            }
            else
            {
                btnDeleteBook.IsEnabled = false;
                btnDeleteTitle.IsEnabled = false;
                btnEditTitle.IsEnabled = false;
                btnAddBook.IsEnabled = false;

            }
        }
        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.1;
            var column2 = 0.1;
            var column3 = 0.2;
            var column4 = 0.2;
            var column5 = 0.1;
            var column6 = 0.1;
            var column7 = 0.1;
            var column8 = 0.1;

            if (gridView != null && width >= 0)
            {
                gridView.Columns[0].Width = width * column1;
                gridView.Columns[1].Width = width * column2;
                gridView.Columns[2].Width = width * column3;
                gridView.Columns[3].Width = width * column4;
                gridView.Columns[4].Width = width * column5;
                gridView.Columns[5].Width = width * column6;
                gridView.Columns[6].Width = width * column7;
                gridView.Columns[7].Width = width * column8;
            }
        }

        private void Button_OpenCreate_Title(object sender, RoutedEventArgs e)
        {
            TitleCreate t = new TitleCreate();
            t.Show();
        }

        private void Button_OpenCreate_Book(object sender, RoutedEventArgs e)
        {
            BookManageModel selectedItem = (BookManageModel)listView.SelectedItem;
            int titleId = selectedItem.TitleId;
            BookCreate t = new BookCreate(titleId);
            t.Show();
        }

        private void Button_Delete_Book(object sender, RoutedEventArgs e)
        {
            BookManageModel selectedItem = (BookManageModel)listView.SelectedItem;

            // Kiểm tra xem mục có tồn tại và có chứa giá trị TitleId không




            MessageBoxResult result = MessageBox.Show("Do you really want to delete this book?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                int titleId = selectedItem.TitleId;
                int bookId = Convert.ToInt32(selectedItem.BookId);

                using var context = new LibraryManagementContext();
                BookInfo? tempInfo = context.BookInfos.FirstOrDefault(x => x.TitleId == titleId);
                Book? bookToDelete = context.Books.FirstOrDefault(x => x.BookId == bookId);
                List<ReturnBookDetail> returnBookDetails = context.ReturnBookDetails.ToList();
                List<ReturnBookDetail> returnBookDetailsDelete = new List<ReturnBookDetail>();
                
                    foreach (ReturnBookDetail r in returnBookDetails)
                    {
                        if (bookToDelete.BookId == r.BookId)
                        {
                            returnBookDetailsDelete.Add(r);
                        }
                    }
                

                if (tempInfo != null)
                {
                    if (bookToDelete != null)
                    {
                        context.RemoveRange(returnBookDetailsDelete);
                        context.Books.Remove(bookToDelete);
                        tempInfo.InStock -= 1;
                        context.BookInfos.Update(tempInfo);
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Book deleted successfully!");
                SetInitialRDAndButton();
                LoadData();
            }
            else
            {
                return;
            }
        }

        private void Button_Edit_Title(object sender, RoutedEventArgs e)
        {
            BookManageModel selectedItem = (BookManageModel)listView.SelectedItem;
            int titleId = selectedItem.TitleId;
            TitleCreate t = new TitleCreate(titleId);
            t.Show();
        }

        private void Button_Delete_Title(object sender, RoutedEventArgs e)
        {
            BookManageModel selectedItem = (BookManageModel)listView.SelectedItem;

            // Kiểm tra xem mục có tồn tại và có chứa giá trị TitleId không
            if (selectedItem != null)
            {
                int titleId = selectedItem.TitleId;
                DeleteTitle(titleId);
                LoadData();
                // Sử dụng titleId như bạn muốn
            }



        }

        public static void DeleteTitle(int titleId)
        {
            using var context = new LibraryManagementContext();
            MessageBoxResult result = MessageBox.Show("Do you really want to delete this title and all books with this title?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                List<AuthorBook> authorBooksToDelete = context.AuthorBooks.Where(x => x.TitleId == titleId).ToList();
                List<Book> booksToDelete = context.Books.Where(x => x.TitleId == titleId).ToList();
                List<BookInfo> bookInfosToDelete = context.BookInfos.Where(x => x.TitleId == titleId).ToList();
                List<ReturnBookDetail> returnBookDetails = context.ReturnBookDetails.ToList();
                List<ReturnBookDetail> returnBookDetailsDelete = new List<ReturnBookDetail>();
                foreach (Book b in booksToDelete)
                {
                    foreach (ReturnBookDetail r in returnBookDetails)
                    {
                        if (b.BookId == r.BookId)
                        {
                            returnBookDetailsDelete.Add(r);
                        }
                    }
                }

                if (booksToDelete.Count > 0)
                {
                    context.RemoveRange(returnBookDetailsDelete);
                    context.RemoveRange(booksToDelete);
                    context.SaveChanges();

                }
                context.RemoveRange(authorBooksToDelete);
                context.SaveChanges();
                context.RemoveRange(bookInfosToDelete);
                context.SaveChanges();


                MessageBox.Show("Deleted Successfully!");
            }
        }
        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}

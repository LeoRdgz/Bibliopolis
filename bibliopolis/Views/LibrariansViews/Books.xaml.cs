using bibliopolis.Entities;
using bibliopolis.Services;
using bibliopolis.Validations;
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

namespace bibliopolis.Views.LibrariansViews
{
    /// <summary>
    /// Lógica de interacción para Books.xaml
    /// </summary>
    public partial class Books : Window
    {
        BookServices services = new BookServices();
        private bool isEditMode;

        public Books()
        {
            InitializeComponent();
            GetBooksTable();
        }

        private void GetBooksTable()
        {
            DataGridBooks.ItemsSource = services.GetBooks();
        }

        private void BTN_Clear_Click()
        {
            TxtISBN.Clear();
            TxtTitle.Clear();
            TxtAuthor.Clear();
            TxtEditorial.Clear();
            TxtUnits.Clear();
            TxtISBN.IsEnabled = true;
        }

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            HomeMenu HomeMenu = new HomeMenu();
            Close();
            HomeMenu.Show();
        }

        private void BTN_EditItem_Click(object sender, EventArgs e) // Misma función que en 'ManageStudents.xaml.cs'
        {
            Book book = new Book();

            book = (sender as FrameworkElement).DataContext as Book;


            TxtISBN.Text = book.ISBN;
            TxtISBN.IsEnabled = false;
            TxtTitle.Text = book.Title;
            TxtAuthor.Text = book.Author;
            TxtEditorial.Text = book.Editorial;
            TxtUnits.Text = book.Units;

            isEditMode = true;
        }

        private void BTN_Save_Click()
        {
            try
            {

                if (!InputValidator.IsNumber(TxtISBN.Text) || !InputValidator.IsNumber(TxtUnits.Text))
                {
                    MessageBox.Show("Por favor, asegúrese de que el ISBN y el número de existencias sean valores numéricos.");
                    return;
                }
                else
                {

                    Book book = new Book();
                    book.ISBN = TxtISBN.Text;
                    book.Title = TxtTitle.Text;
                    book.Author = TxtAuthor.Text;
                    book.Editorial = TxtEditorial.Text;
                    book.Units = TxtUnits.Text;

                    if (isEditMode)
                    {
                        isEditMode = false;
                        services.UpdateBook(book);
                        MessageBox.Show("Libro editado correctamente");
                    }
                    else
                    {
                        services.AddBook(book);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el libro.\n {ex.Message}");
            }
        }
    }
}

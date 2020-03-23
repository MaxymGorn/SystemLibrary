using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp9.Model;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    enum Table
    {
        Manager,
        Libraryan,
        Readers,
        Category,
        Autors,
        Books = 5,
        Publisher =7
    }
    public partial class MainWindow : Window
    {
        private bool _blue;
        private Database1Entities1 Database1Entities;
        private bool er;

        public MainWindow()
        {
            InitializeComponent();
            Database1Entities = new Database1Entities1();
            DeleteTab_Menu();
            LoadManagers();
            _blue = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeDictionares();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu2.Visibility = Visibility.Collapsed;
            ButtonOpenMenu3.Visibility = Visibility.Collapsed;
            ButtonOpenMenu4.Visibility = Visibility.Collapsed;
            ButtonOpenMenu5.Visibility = Visibility.Collapsed;
            ButtonOpenMenu6.Visibility = Visibility.Collapsed;
            ButtonOpenMenu7.Visibility = Visibility.Collapsed;
            ButtonOpenMenu8.Visibility = Visibility.Collapsed;

            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu2.Visibility = Visibility.Visible;
            ButtonCloseMenu3.Visibility = Visibility.Visible;
            ButtonCloseMenu4.Visibility = Visibility.Visible;
            ButtonCloseMenu5.Visibility = Visibility.Visible;
            ButtonCloseMenu6.Visibility = Visibility.Visible;
            ButtonCloseMenu7.Visibility = Visibility.Visible;
            ButtonCloseMenu8.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu2.Visibility = Visibility.Visible;
            ButtonOpenMenu3.Visibility = Visibility.Visible;
            ButtonOpenMenu4.Visibility = Visibility.Visible;
            ButtonOpenMenu5.Visibility = Visibility.Visible;
            ButtonOpenMenu6.Visibility = Visibility.Visible;
            ButtonOpenMenu7.Visibility = Visibility.Visible;
            ButtonOpenMenu8.Visibility = Visibility.Visible;

            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu2.Visibility = Visibility.Collapsed;
            ButtonCloseMenu3.Visibility = Visibility.Collapsed;
            ButtonCloseMenu4.Visibility = Visibility.Collapsed;
            ButtonCloseMenu5.Visibility = Visibility.Collapsed;
            ButtonCloseMenu6.Visibility = Visibility.Collapsed;
            ButtonCloseMenu7.Visibility = Visibility.Collapsed;
            ButtonCloseMenu8.Visibility = Visibility.Collapsed;
        }

  
        #region Load Data
        private void LoadManagers()
        {
            textbox_manager_fullname.Text = "";
            textbox_manager_contact.Text = "";
            list_Data.Items.Clear();
            foreach (var el in Database1Entities.Managers)
            {
                list_Data.Items.Add(el);
            }
        }
        private void LoadReaders()
        {
            textbox_readers_contact.Text = "";
            textbox_readers_name.Text = "";
            list_Data_Readers.Items.Clear();
            foreach (var el in Database1Entities.Readers)
            {
                list_Data_Readers.Items.Add(el);
            }
        }
        private void LoadCategory()
        {
            textbox_categoty_name.Text = "";
            list_Data_category.Items.Clear();
            foreach (var el in Database1Entities.Genres)
            {
                list_Data_category.Items.Add(el);
            }
        }
        private void LoadAutors()
        {
            textbox_autor_name.Text = "";
            list_Data_autor.Items.Clear();
            foreach (var el in Database1Entities.Authors)
            {
                list_Data_autor.Items.Add(el);
            }
        }
        private void LoadPublisher()
        {
            textbox_publisher_name.Text = "";
            list_Data_publisher.Items.Clear();
            foreach (var el in Database1Entities.Publishers)
            {
                list_Data_publisher.Items.Add(el);
            }
        }
        private void LoadBooks()
        {
            textbox_books_name.Text = "";
            list_Data_books.Items.Clear();
            ComboBox_Genres.Items.Clear();
            ComboBox_Publishers.Items.Clear();
            foreach (var el in Database1Entities.Books)
            {
                list_Data_books.Items.Add(el);
            }
            foreach (var el in Database1Entities.Genres)
            {
                ComboBox_Genres.Items.Add(el);
            }
            foreach (var el in Database1Entities.Publishers)
            {
                ComboBox_Publishers.Items.Add(el);
            }

        }
        #endregion
        #region Delete Data

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (tabControl1.SelectedIndex == (int)Table.Manager)
            {
                Deletemanager();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Readers)
            {
                DeleteReaders();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Category)
            {
                DeleteCategory();
            }
            else if(tabControl1.SelectedIndex == (int)Table.Autors)
            {
                DeleteAutor();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Publisher)
            {
                DeletePublisher();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Books)
            {
                DeleteBooks();
            }

        }
        private void Deletemanager()
        {
            er = true;
            try
            {
                Manager manager = (Manager)list_Data.SelectedItems[0];
                var el = Database1Entities.Managers.Where(ee => ee.Id == manager.Id);
                foreach (var rem in el)
                {
                    Database1Entities.Managers.Remove(rem);
                }
                Database1Entities.SaveChanges();
                LoadManagers();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
           
        }
        private void DeleteReaders()
        {
            er = true;
            try
            {
                Reader reader = (Reader)list_Data_Readers.SelectedItems[0];
                var el = Database1Entities.Readers.Where(ee => ee.Id == reader.Id);
                foreach (var rem in el)
                {
                    Database1Entities.Readers.Remove(rem);
                }
                Database1Entities.SaveChanges();
                LoadReaders();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
        }
        private void DeleteCategory()
        {
            er = true;
            try
            {
                Genre genre = (Genre)list_Data_category.SelectedItems[0];
                var el = Database1Entities.Genres.Where(ee => ee.Id == genre.Id);
                foreach (var rem in el)
                {
                    Database1Entities.Genres.Remove(rem);
                }
                Database1Entities.SaveChanges();
                LoadCategory();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
        }
        private void DeleteAutor()
        {
            er = true;
            try
            {
                Author author = (Author)list_Data_autor.SelectedItems[0];
                var el = Database1Entities.Authors.Where(ee => ee.Id == author.Id);
                foreach (var rem in el)
                {
                    Database1Entities.Authors.Remove(rem);
                }
                Database1Entities.SaveChanges();
                LoadAutors();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
        }
        private void DeletePublisher()
        {
            er = true;
            try
            {
                Publisher publisher = (Publisher)list_Data_publisher.SelectedItems[0];
                var el = Database1Entities.Publishers.Where(ee => ee.Id == publisher.Id);
                foreach (var rem in el)
                {
                    Database1Entities.Publishers.Remove(rem);
                }
                Database1Entities.SaveChanges();
                LoadPublisher();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
        }
        private void DeleteBooks()
        {
            er = true;
            try
            {
                Book book = (Book)list_Data_books.SelectedItems[0];
                var el = Database1Entities.Books.Where(ee => ee.Id == book.Id);
                foreach (var rem in el)
                {
                    Database1Entities.Books.Remove(rem);
                }
                Database1Entities.SaveChanges();
                LoadBooks();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка удаления!");
            }
        }
        #endregion
        #region Save Data

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (tabControl1.SelectedIndex == (int)Table.Manager)
            {
                Manager_Save();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Readers)
            {
                Reader_Save();
            }
            else if(tabControl1.SelectedIndex == (int)Table.Category)
            {
                Category_Save();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Autors)
            {
                Autor_Save();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Publisher)
            {
                Publisher_Save();
            }
            else if (tabControl1.SelectedIndex == (int)Table.Books)
            {
                Book_Save();  
            }
        }
        void Reader_Save()
        {
            er = true;
            try
            {
                Reader reader = list_Data_Readers.SelectedItems[0] as Reader;
                IEnumerable<int> Id_ie = from n in queryable<Reader>().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0] != reader.Id)
                {
                    throw new Exception("Такой читатель уже существует!!!");
                }
                var s = Database1Entities.Readers.Where(ee => ee.Id == reader.Id).ToList()[0];
                s.Contact = textbox_readers_contact.Text;
                s.Name = textbox_readers_name.Text;
                Database1Entities.SaveChanges();
                LoadReaders();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }
        void Manager_Save()
        {
            er = true;
            try
            {
                Manager manager = list_Data.SelectedItems[0] as Manager;
                IEnumerable<int> Id_ie = from n in queryable<Manager>().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0] != manager.Id)
                {
                    throw new Exception("Такой менеджер уже существует!!!");
                }
                var s = Database1Entities.Managers.Where(ee => ee.Id == manager.Id).ToList()[0];
                s.Contact = textbox_manager_contact.Text;
                s.Name = textbox_manager_fullname.Text;
                Database1Entities.SaveChanges();
                LoadManagers();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }
        void Category_Save()
        {
            er = true;
            try
            {
                Genre genre = list_Data_category.SelectedItems[0] as Genre;
                IEnumerable<int> Id_ie = from n in queryable<Genre>().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0] != genre.Id)
                {
                    throw new Exception("Такая категория уже существует!!!");
                }
                var s = Database1Entities.Genres.Where(ee => ee.Id == genre.Id).ToList()[0];
                s.Name = textbox_categoty_name.Text;
                Database1Entities.SaveChanges();
                LoadCategory();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }
        void Autor_Save()
        {
            er = true;
            try
            {
                Author author = list_Data_autor.SelectedItems[0] as Author;
                IEnumerable<int> Id_ie = from n in queryable<Author>().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0] != author.Id)
                {
                    throw new Exception("Такой автор уже существует!!!");
                }
                var s = Database1Entities.Authors.Where(ee => ee.Id == author.Id).ToList()[0];
                s.Name = textbox_autor_name.Text;
                Database1Entities.SaveChanges();
                LoadAutors();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }

        void Publisher_Save()
        {
            er = true;
            try
            {
                Publisher publisher = list_Data_publisher.SelectedItems[0] as Publisher;
                IEnumerable<int> Id_ie = from n in queryable<Publisher>().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0] != publisher.Id)
                {
                    throw new Exception("Такой автор уже существует!!!");
                }
                var s = Database1Entities.Publishers.Where(ee => ee.Id == publisher.Id).ToList()[0];
                s.Name = textbox_publisher_name.Text;
                Database1Entities.SaveChanges();
                LoadPublisher();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }

        void Book_Save()
        {
            er = true;
            try
            {
                Book book = list_Data_books.SelectedItems[0] as Book;
                IEnumerable<int> Id_ie = from n in queryable< Book>().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0] != book.Id)
                {
                    throw new Exception("Такая книга уже существует!!!");
                }
                var s = Database1Entities.Books.Where(ee => ee.Id == book.Id).ToList()[0];
                s.Name = textbox_books_name.Text;
                s.Pages = int.Parse(textbox_books_pages.Text);
                s.Price = decimal.Parse(textbox_books_price.Text);
                s.Year = int.Parse(textbox_books_year.Text);
                TextBlock textBlock = UIHelper.FindChild<TextBlock>(ComboBox_Genres, "tmp");
                TextBlock textBlock2 = UIHelper.FindChild<TextBlock>(ComboBox_Publishers, "tmp2");
                s.GenreId = GetGenres(textBlock.Text);
                s.PublisherId = GetPublish(textBlock2.Text);
                Database1Entities.SaveChanges();
                LoadBooks();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }

        #endregion
        #region Selection Change
        private void list_Data_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SelectionChange();
        }
        private void SelectionChange()
        {
            try
            {
                if (er == false)
                {
                    throw new Exception();
                }
                er = false;
            }
            catch (Exception)
            {
                if (tabControl1.SelectedIndex == (int)Table.Manager)
                {
                    Manager manager = list_Data.SelectedItems[0] as Manager;
                    textbox_manager_contact.Text = manager.Contact;
                    textbox_manager_fullname.Text = manager.Name;
                }
                else if (tabControl1.SelectedIndex == (int)Table.Readers)
                {
                    Reader reader = list_Data_Readers.SelectedItems[0] as Reader;
                    textbox_readers_contact.Text = reader.Contact;
                    textbox_readers_name.Text = reader.Name;
                }
                else if (tabControl1.SelectedIndex == (int)Table.Category)
                {
                    Genre genre = list_Data_category.SelectedItems[0] as Genre;
                    textbox_categoty_name.Text = genre.Name;
                }
                else if (tabControl1.SelectedIndex == (int)Table.Autors)
                {
                    Author author = list_Data_autor.SelectedItems[0] as Author;
                    textbox_autor_name.Text = author.Name;
                }
                else if (tabControl1.SelectedIndex == (int)Table.Publisher)
                {
                    Publisher publisher = list_Data_publisher.SelectedItems[0] as Publisher;
                    textbox_publisher_name.Text = publisher.Name;
                }
                else if (tabControl1.SelectedIndex == (int)Table.Books)
                {
                    Book book = list_Data_books.SelectedItems[0] as Book;
                    textbox_books_name.Text = book.Name;
                    textbox_books_pages.Text = book.Pages.ToString();
                    textbox_books_price.Text = book.Price.ToString();
                    textbox_books_year.Text = book.Year.ToString();
                    //Book books = (Book)list_Data_books.SelectedItems[0];             
                    

                }
            }
        }
        #endregion
        #region Add Data
            private void Button_Click_Add(object sender, RoutedEventArgs e)
            {
                if (tabControl1.SelectedIndex == (int)Table.Manager)
                {
                    AddManager();
                }
                else if (tabControl1.SelectedIndex == (int)Table.Readers)
                {
                    AddReader();
                }
                else if (tabControl1.SelectedIndex == (int)Table.Category)
                {
                    AddGenre();
                }
                else if(tabControl1.SelectedIndex == (int)Table.Autors)
                {
                    AddAutor();
                }
                else if (tabControl1.SelectedIndex == (int)Table.Publisher)
                {
                    AddPublisher();
                }
            else if (tabControl1.SelectedIndex == (int)Table.Books)
            {
                AddBooks();
            }
        }
            void AddReader()
            {
                er = true;
                try
                {
                    if (textbox_readers_contact.Text == "" || textbox_readers_name.Text == "")
                    {
                        throw new Exception();
                    }
                    if (queryable<Reader>().ToArray().Length > 0)
                    {
                        throw new Exception("Такой читатель уже существует!!!");
                    }
                    Database1Entities.Readers.Add(new Reader()
                    {
                        Name = textbox_readers_name.Text,
                        Contact = textbox_readers_contact.Text
                    });
                    Database1Entities.SaveChanges();
                    LoadReaders();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Ошыбка!");
                }
            }
            void AddManager()
            {
                er = true;
                try
                {
                    if (textbox_manager_contact.Text == "" || textbox_manager_fullname.Text == "")
                    {
                        throw new Exception();
                    }
                    if (queryable<Manager>().ToArray().Length > 0)
                    {
                        throw new Exception("Такой менеджер уже существует!!!");
                    }
                    Database1Entities.Managers.Add(new Manager()
                    {
                        Name = textbox_manager_fullname.Text,
                        Contact = textbox_manager_contact.Text
                    });
                    Database1Entities.SaveChanges();
                    LoadManagers();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Ошыбка!");
                }

            }
            void AddGenre()
            {
                er = true;
                try
                {
                    if (textbox_categoty_name.Text == "" )
                    {
                        throw new Exception();
                    }
                    if (queryable<Genre>().ToArray().Length > 0)
                    {
                        throw new Exception("Такая категория уже существует!!!");
                    }
                    Database1Entities.Genres.Add(new Genre()
                    {
                        Name = textbox_categoty_name.Text
                    });
                    Database1Entities.SaveChanges();
                    LoadCategory();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Ошыбка!");
                }

            }
            void AddAutor()
            {
                er = true;
                try
                {
                    if (textbox_autor_name.Text == "" )
                    {
                        throw new Exception();
                    }
                    if (queryable<Author>().ToArray().Length > 0)
                    {
                        throw new Exception("Такой автор уже существует!!!");
                    }
                    Database1Entities.Authors.Add(new Author()
                    {
                        Name = textbox_autor_name.Text
                    });
                    Database1Entities.SaveChanges();
                    LoadAutors();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Ошыбка!");
                }

            }
        void AddPublisher()
        {
            er = true;
            try
            {
                if (textbox_publisher_name.Text == "")
                {
                    throw new Exception();
                }
                if (queryable<Publisher>().ToArray().Length > 0)
                {
                    throw new Exception("Такой издатель уже существует!!!");
                }
                Database1Entities.Publishers.Add(new Publisher()
                {
                    Name = textbox_publisher_name.Text
                });
                Database1Entities.SaveChanges();
                LoadPublisher();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }

        }
        void AddBooks()
        {
            er = true;
            try
            {
                if (textbox_books_name.Text == "" || textbox_books_pages.Text=="" || textbox_books_price.Text=="" || textbox_books_year.Text=="")
                {
                    throw new Exception();
                }
                if(ComboBox_Genres.Text=="" ||ComboBox_Publishers.Text == "")
                {
                    throw new Exception();
                }
                //int.Parse(textbox_books_year.Text);
                //int.Parse(textbox_books_pages.Text);
                //decimal.Parse(textbox_books_price.Text);
                if (queryable<Book>().ToArray().Length > 0)
                {
                    throw new Exception("Такая книга уже существует!!!");
                }
                TextBlock textBlock = UIHelper.FindChild<TextBlock>(ComboBox_Genres, "tmp");
                TextBlock textBlock2 = UIHelper.FindChild<TextBlock>(ComboBox_Publishers, "tmp2");
                Database1Entities.Books.Add(new Book()
                {
                    Name = textbox_books_name.Text,
                    Price=decimal.Parse(textbox_books_price.Text),
                    Year=int.Parse(textbox_books_year.Text),
                    Pages=int.Parse(textbox_books_pages.Text),
                    GenreId= GetGenres(textBlock.Text),
                    PublisherId= GetPublish(textBlock2.Text)
                });
                Database1Entities.SaveChanges();
                LoadBooks();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }

        }
        #endregion
        #region Menu Change
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Manager;
            er = false;
            LoadManagers();
            Name_menu.Text = "Менеджери";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Libraryan;
          
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Readers;
            er = false;
            LoadReaders();
            Name_menu.Text = "Читатели";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Category;
            er = false;
            LoadCategory();
            Name_menu.Text = "Категории";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Autors;
            er = false;
            LoadAutors();
            Name_menu.Text = "Авторы";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Books;
            er = false;
            LoadBooks();
            Name_menu.Text = "Книги";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 6;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = (int)Table.Publisher;
            er = false;
            LoadPublisher();
            Name_menu.Text = "Издатели";
        }
        #endregion
        IEnumerable<(T, int)> queryable<T>() where T:class
        {
            Type typeParameterType = typeof(T);
            if (typeParameterType == typeof(Manager))
            {
                foreach (var dr in Database1Entities.Managers)
                {
                    if (dr.Name.Contains(textbox_manager_fullname.Text))
                    {
                        yield return ((T)Convert.ChangeType(dr, typeof(T)), dr.Id);
                    }
                }
            }
            //else if(typeParameterType == typeof(Library))
            //{

            //}
            else if(typeParameterType == typeof(Reader))
            {
                foreach (var dr in Database1Entities.Readers)
                {
                    if (dr.Name.Contains(textbox_readers_name.Text))
                    {
                        yield return ((T)Convert.ChangeType(dr, typeof(T)), dr.Id);
                    }
                }
            }
            else if (typeParameterType == typeof(Genre))
            {
                foreach (var dr in Database1Entities.Genres)
                {
                    if (dr.Name.Contains(textbox_categoty_name.Text))
                    {
                        yield return ((T)Convert.ChangeType(dr, typeof(T)), dr.Id);
                    }
                }
            }
            else if (typeParameterType == typeof(Author))
            {
                foreach (var dr in Database1Entities.Authors)
                {
                    if (dr.Name.Contains(textbox_autor_name.Text))
                    {
                        yield return ((T)Convert.ChangeType(dr, typeof(T)), dr.Id);
                    }
                }
            }
            else if (typeParameterType == typeof(Book))
            {
                foreach (var dr in Database1Entities.Books)
                {
                    if (dr.Name.Contains(textbox_books_name.Text))
                    {
                        yield return ((T)Convert.ChangeType(dr, typeof(T)), dr.Id);
                    }
                }
            }
            else if (typeParameterType == typeof(Publisher))
            {
                foreach (var dr in Database1Entities.Publishers)
                {
                    if (dr.Name.Contains(textbox_publisher_name.Text))
                    {
                        yield return ((T)Convert.ChangeType(dr, typeof(T)), dr.Id);
                    }
                }
            }
        }

        void DeleteTab_Menu()
        {
            foreach (var item in tabControl1.Items)
            {
                (item as TabItem).Visibility = Visibility.Collapsed;
            }
        }
        void ChangeDictionares()
        {
            if (_blue)
                Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary() { Source = new Uri("Blue.xaml", UriKind.Relative) };
            else
                Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary() { Source = new Uri("Black.xaml", UriKind.Relative) };
            _blue = !_blue;
        }
        public int GetGenres(string name)
        {
            foreach (var dr in Database1Entities.Genres)
            {
                if (dr.Name==name)
                {
                    return dr.Id;
                }
            }
            return 1;

        }
        public string GetGenres(int name)
        {
            foreach (var dr in Database1Entities.Genres)
            {
                if (dr.Id == name)
                {
                    return dr.Name;
                }
            }
            return "null";

        }

        public int GetPublish(string name)
        {
            foreach (var dr in Database1Entities.Publishers)
            {
                if (dr.Name.Contains(name))
                {
                    return dr.Id;
                }
            }
            return 0;

        }

    }


}
public static class UIHelper
{
    public static T FindChild<T>(DependencyObject parent, string childName)
       where T : DependencyObject
    {
        // Confirm parent and childName are valid. 
        if (parent == null) return null;

        T foundChild = null;

        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < childrenCount; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            // If the child is not of the request child type child
            T childType = child as T;
            if (childType == null)
            {
                // recursively drill down the tree
                foundChild = FindChild<T>(child, childName);

                // If the child is found, break so we do not overwrite the found child. 
                if (foundChild != null) break;
            }
            else if (!string.IsNullOrEmpty(childName))
            {
                var frameworkElement = child as FrameworkElement;
                // If the child's name is set for search
                if (frameworkElement != null && frameworkElement.Name == childName)
                {
                    // if the child's name is of the request name
                    foundChild = (T)child;
                    break;
                }
            }
            else
            {
                // child element found.
                foundChild = (T)child;
                break;
            }
        }

        return foundChild;
    }


}

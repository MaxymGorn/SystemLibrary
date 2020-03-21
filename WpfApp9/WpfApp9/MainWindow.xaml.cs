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
    public partial class MainWindow : Window
    {
        private bool _blue;
        private Database1Entities1 Database1Entities;
        private bool er;

        public MainWindow()
        {
            InitializeComponent();
            Database1Entities = new Database1Entities1();
            LoadManagers();
            _blue = false;
            er = false;
            foreach (var item in tabControl1.Items)
                (item as TabItem).Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_blue)
                Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary() { Source = new Uri("Blue.xaml", UriKind.Relative) };
            else
                Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary() { Source = new Uri("Black.xaml", UriKind.Relative) };
            _blue = !_blue;
        }
        private void LoadManagers()
        {
            textbox1.Text = "";
            textbox2.Text = "";
            list_Data.Items.Clear();
            foreach (var el in Database1Entities.Managers)
            {
                 list_Data.Items.Add(el);
            }
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void list_Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        IEnumerable<(Manager,int)> queryable2()
        {
            foreach (var dr in Database1Entities.Managers)
            {
                if (dr.Name.Contains(textbox1.Text))
                {
                    yield return (dr,dr.Id);
                }
            }
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Deletemanager();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                er = true;
                try
                {
                    if (textbox1.Text == "" || textbox2.Text == "")
                    {
                        throw new Exception();
                    }
                    if (queryable2().ToArray().Length > 0)
                    {
                        throw new Exception("Такой менеджер уже существует!!!");
                    }
                    Database1Entities.Managers.Add(new Manager()
                    {
                        Name = textbox1.Text,
                        Contact = textbox2.Text
                    });
                     Database1Entities.SaveChanges();
                    LoadManagers();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Ошыбка!");
                }
           
            
        }

        private void list_Data_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (er == false)
                {
                    throw new Exception();
                }
                er = false;
            }
            catch(Exception)
            {
                Manager manager = list_Data.SelectedItems[0] as Manager;
                textbox2.Text = manager.Contact;
                textbox1.Text = manager.Name;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            er = true;
            try
            {            
                Manager manager = list_Data.SelectedItems[0] as Manager;
                IEnumerable<int> Id_ie = from n in queryable2().ToList() select n.Item2;
                if (Id_ie.ToList().Count > 0 && Id_ie.ToList()[0]!=manager.Id)
                {
                    throw new Exception("Такой менеджер уже существует!!!");
                }
                var s=Database1Entities.Managers.Where(ee =>  ee.Id == manager.Id).ToList()[0];
                s.Contact = textbox2.Text;
                s.Name = textbox1.Text;
                Database1Entities.SaveChanges();
                LoadManagers();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Ошыбка!");
            }
        }

   
    }
}

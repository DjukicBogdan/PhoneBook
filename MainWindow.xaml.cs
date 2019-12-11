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
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public static int ID = 0;       

        public MainWindow()
        {
            InitializeComponent();

            ReadPhoneBook();
        }

        private void ReadPhoneBook()
        {
            DatagridList.ItemsSource = null;
            DatagridList.Items.Clear();
            DatagridList.Items.Refresh();
            Table.Persons.Clear();
            PhonebookContext context = new PhonebookContext();
            context.Tables.Load();
            foreach (Table table in from Table person in context.Tables.ToList()
                                    let table = new Table
                                    {
                                        Id = person.Id,
                                        Name = person.Name,
                                        Phone = person.Phone,
                                        Mobile = person.Mobile,
                                        Email = person.Email,
                                        Address = person.Address
                                    }
                                    select table)
            {
                Table.Persons.Add(table);
            }
            DatagridList.ItemsSource = Table.Persons.ToList();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            WindowNew winNew = new WindowNew();
            winNew.ShowDialog();
            ReadPhoneBook();       
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            object item = DatagridList.SelectedItem;
            if (item == null)
            {
                return;
            }
            int id = Convert.ToInt32((DatagridList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            try
            {
                using (PhonebookContext context = new PhonebookContext())
                {
                    Table person = context.Tables.FirstOrDefault(x => x.Id == id);
                    if (person == null)
                    {
                        return;
                    }
                    context.Tables.Remove(person);                  
                    context.SaveChanges();
                    ReadPhoneBook();                  
                }
            }
            catch (Exception exc)
            {
               MessageBox.Show("Error message: " + exc);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            object item = DatagridList.SelectedItem;
            if (item == null)
            {
                return;
            }
            int id = Convert.ToInt32((DatagridList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            try
            {
                using (PhonebookContext context = new PhonebookContext())
                {
                    Table person = context.Tables.FirstOrDefault(x => x.Id == id);
                    if (person == null)
                    {
                        return;
                    }
                    ID = person.Id;
                    WindowEdit winEdit = new WindowEdit();
                    winEdit.ShowDialog();
                    ReadPhoneBook();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error message: " + exc);
            }
        }

        private void TextBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxSearch.Text = "";
        }

        private void TextBoxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxSearch.Text = "Search...";
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string SearchForName = TextBoxSearch.Text;

            if (!string.IsNullOrEmpty(TextBoxSearch.Text) && !string.IsNullOrWhiteSpace(TextBoxSearch.Text) && TextBoxSearch.Text != "Search...")
            {
                var FilteredName = Table.Persons.Where(p => p.Name.ToString().ToLower().Contains(SearchForName.ToLower()));
                DatagridList.ItemsSource = FilteredName.ToList();
            }        

            else
            {
                DatagridList.ItemsSource = null;
                DatagridList.Items.Clear();
                DatagridList.Items.Refresh();
                DatagridList.ItemsSource = Table.Persons.ToList();
            }
        }
    }
}

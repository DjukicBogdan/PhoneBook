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

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for WindowNew.xaml
    /// </summary>
    public partial class WindowNew : Window
    {
        public WindowNew()
        {
            InitializeComponent();

            TextBoxName.Focus();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var contex = new PhonebookContext())
                {
                    Table table = new Table()
                    {
                        Name = TextBoxName.Text,
                        Phone = TextBoxPhone.Text,
                        Mobile = TextBoxMobile.Text,
                        Email = TextBoxEmail.Text,
                        Address = TextBoxAddress.Text
                    };
                    contex.Tables.Add(table);
                    contex.SaveChanges();
                    Table.Persons.Add(table);
                   
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error message: " + exc);
            }
        }
    }
}

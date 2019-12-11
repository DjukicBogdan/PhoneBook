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
    /// Interaction logic for WindowEdit.xaml
    /// </summary>
    public partial class WindowEdit : Window
    {
        public WindowEdit()
        {
            InitializeComponent();

            try
            {
                using (PhonebookContext context = new PhonebookContext())
                {
                    Table person = new Table();
                    person = context.Tables.FirstOrDefault(x => x.Id == MainWindow.ID);
                    if (person == null)
                    {
                        this.Close();
                    }
                    TextBoxName.Text = person.Name;
                    TextBoxPhone.Text = person.Phone;
                    TextBoxMobile.Text = person.Mobile;
                    TextBoxEmail.Text = person.Email;
                    TextBoxAddress.Text = person.Address;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error message: " + exc);
            }                     
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var contex = new PhonebookContext())
                {
                    Table table = (from t in contex.Tables where t.Id == MainWindow.ID select t).First();

                    table.Name = TextBoxName.Text;
                    table.Phone = TextBoxPhone.Text;
                    table.Mobile = TextBoxMobile.Text;
                    table.Email = TextBoxEmail.Text;
                    table.Address = TextBoxAddress.Text;                                       
                    contex.SaveChanges();
                    
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Barber.Windows
{
    /// <summary>
    /// Interaction logic for AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        private Table<LinqGender> Genders;
        
        public AddNewClient()
        {
            InitializeComponent();

            //DataTable dataTable = DataBaseConnector.GetDataTable("SELECT id, name, description FROM Genders");

            Genders = DataBaseConnector.GetBarberShop().Genders;
            
            foreach (LinqGender gender in Genders)
            {
                Gender.Items.Add(gender);
            }
        }

        private void Phone_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckPhoneBox(sender as TextBox);
            AddButton.IsEnabled = AllIsGood();
        }

        private void Name_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckNameBox(sender as TextBox);
            AddButton.IsEnabled = AllIsGood();
        }

        private void Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckEmailBox(sender as TextBox);
            AddButton.IsEnabled = AllIsGood();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool AllIsGood()
        {
            if (!Regex.Match(Phone.Text, @"^[+](\d+[-])+\d+$").Success) return false;
            if (!Regex.Match(Email.Text, @"^[A-Z a-z . _ 0-9]+[@]\w+[.]\w+$").Success) return false;
            if (!Regex.Match(Name.Text, @"^[A-Z a-z А-Я а-я]+$").Success) return false;
            if (!Regex.Match(Surname.Text, @"^[A-Z a-z А-Я а-я]+$").Success) return false;
            //if (!Regex.Match(Gender.Text, @"^\d+$").Success) return false;
            return true;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (AllIsGood())
            {
                DataBaseConnector.NonQueryCommand(
                    $"INSERT Clients(name, surname, phone, email, genderID) " +
                    $"VALUES ((N'{Name.Text}'), (N'{Surname.Text}'), (N'{Phone.Text}'), (N'{Email.Text}'), (N'{Gender.SelectedIndex}'))");
                MessageBox.Show("Client added successfully", "Success", MessageBoxButton.OK);
                Name.Text = "";
                Surname.Text = "";
                Phone.Text = "";
                Email.Text = "";
                Gender.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Check spelling", "ERROR", MessageBoxButton.OK);
            }
        }

        private void Gender_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((ToolTip)Gender.ToolTip).Content = (Gender.SelectedItem as LinqGender).Description;
        }

        private void ResetGender_OnClick(object sender, RoutedEventArgs e)
        {
            Gender.SelectedIndex = -1;
        }
    }
}

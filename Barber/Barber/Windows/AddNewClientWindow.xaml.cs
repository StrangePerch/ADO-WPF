using System;
using System.Collections.Generic;
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
        public AddNewClient()
        {
            InitializeComponent();
        }

        private void Phone_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            Match match = Regex.Match(box.Text, @"^[+](\d+[-])+\d+$");
            box.Foreground = match.Success ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
        }

        private void Name_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            Match match = Regex.Match(box.Text, @"^[A-Z a-z А-Я а-я]+$");
            box.Foreground = match.Success ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
        }

        private void Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            Match match = Regex.Match(box.Text, @"^[A-Z a-z . _ 0-9]+[@]\w+[.]\w+$");
            box.Foreground = match.Success ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
        }

        private void Gender_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            Match match = Regex.Match(box.Text, @"^\d+$");
            box.Foreground = match.Success ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Red);
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
            if (!Regex.Match(Gender.Text, @"^\d+$").Success) return false;
            return true;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (AllIsGood())
            {
                DataBaseConnector.NonQueryCommand(
                    $"INSERT Clients(name, surname, phone, email, genderID) " +
                    $"VALUES ((N'{Name.Text}'), (N'{Surname.Text}'), (N'{Phone.Text}'), (N'{Email.Text}'), (N'{Gender.Text}'))");
                MessageBox.Show("Client added successfully", "Success", MessageBoxButton.OK);
                Close();
            }
            else
            {
                MessageBox.Show("Check spelling", "ERROR", MessageBoxButton.OK);
            }
        }
    }
}

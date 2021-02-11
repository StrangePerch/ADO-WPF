using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Barber.Windows
{
    /// <summary>
    /// Interaction logic for ClientForm.xaml
    /// </summary>
    public partial class ClientForm : Window
    {
        private List<Client> Clients;
        private List<string> Genders;
        private int index = 0;

        public ICommand NextCommand { get; set; }
        public ICommand PrevCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public bool Changed { get; set; }

        
        public ClientForm()
        {
            InitializeComponent();

            DataContext = this;

            DataTable dataTable = DataBaseConnector.GetDataTable("SELECT id, name FROM Genders");

            foreach (DataRow row in dataTable.Rows)
            {
                Gender.Items.Add(row.ItemArray[1]);
            }

            NextCommand = new Command(Next, CanNext);
            PrevCommand = new Command(Prev, CanPrev);
            SaveCommand = new Command(Save, IsChanged);
        }

        private bool IsChanged(object sender)
        {
            return Changed && CheckAll();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Prev(object sender)
        {
            if (index > 0)
            {
                index--;
                ShowClient();
            }
        }

        private void Next(object sender)
        {
            if (index < Clients.Count - 1)
            {
                index++;
                ShowClient();
            }
        }

        private bool CanNext(object sender)
        {
            if (Clients == null) return false;
            return index != Clients.Count - 1;
        }

        private bool CanPrev(object sender)
        {
            return index != 0;
        }

        private void ShowClient()
        {
            Name.Text = Clients[index].Name;
            Surname.Text = Clients[index].Surname;
            Email.Text = Clients[index].Email;
            Phone.Text = Clients[index].Phone;
            Gender.SelectedIndex = Clients[index].GenderId;

            PrevButton.IsEnabled = index != 0;
            NextButton.IsEnabled = index != Clients.Count - 1;

            ((ToolTip) Gender.ToolTip).Content = Clients[index].GenderDescription;
            Changed = false;
        }

        private void ClientForm_OnLoaded(object sender, RoutedEventArgs e)
        {
            Clients = new List<Client>();
            // ORM-3 заполнение коллекции
            try
            {
                SqlDataReader reader = DataBaseConnector.GetReader(
                    "SELECT C.id, C.name, surname, email, phone, COALESCE(genderId,'-'), COALESCE(G.description, '-') FROM Clients C LEFT JOIN Genders G ON C.GenderID = G.Id");
                while (reader.Read())
                {
                    Clients.Add(
                        new Client()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.GetString(4),
                            GenderId = (reader.GetValue(5) == DBNull.Value) ? 0 : reader.GetInt32(5),
                            GenderDescription = reader.GetString(6)
                        }
                    );
                }
                reader.Close();  // С незакрытым reader блокируется connection
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            DataTable dataTable = DataBaseConnector.GetDataTable("SELECT id, name FROM Genders");
            Genders = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                Genders.Add(row.ItemArray[1].ToString());
            }

            ShowClient();
        }

        private bool CheckAll()
        {
            if (!TextCheck.CheckName(Name.Text)) return false;
            if (!TextCheck.CheckName(Surname.Text)) return false;
            if (!TextCheck.CheckPhone(Phone.Text)) return false;
            if (!TextCheck.CheckEmail(Email.Text)) return false;
            return true;
        }

        private void Save(object sender)
        {
            Clients[index].Name = Name.Text;
            Clients[index].Surname = Surname.Text;
            Clients[index].Email = Email.Text;
            Clients[index].Phone = Phone.Text;
            Clients[index].GenderId = Gender.SelectedIndex;
             
            Client temp = Clients[index];
            DataBaseConnector.NonQueryCommand(
                $"UPDATE Clients SET name = N'{temp.Name}', surname = N'{temp.Surname}', phone = '{temp.Phone}', email = '{temp.Email}', genderID = '{temp.GenderId}' WHERE id = '{temp.Id}'");
            MessageBox.Show("Saved successfully", "Saved", MessageBoxButton.OK);

            Changed = false;
        }

        private void Name_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckNameBox(sender as TextBox);
            Changed = true;
        }

        private void Surname_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckNameBox(sender as TextBox);
            Changed = true;
        }

        private void Phone_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckPhoneBox(sender as TextBox);
            Changed = true;
        }

        private void Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextCheck.CheckEmailBox(sender as TextBox);
            Changed = true;
        }

        private void ResetGender_OnClick(object sender, RoutedEventArgs e)
        {
            Gender.SelectedIndex = -1;
        }

        private void Gender_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Changed = true;
        }
    }
}

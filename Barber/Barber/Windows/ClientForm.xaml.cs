using System;
using System.Collections.Generic;
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
        private int index = 0;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (index < Clients.Count - 1)
            {
                index++;
                ShowClient();
            }
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PrevButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                ShowClient();
            }
        }

        private void ShowClient()
        {
            Name.Text = Clients[index].Name;
            Surname.Text = Clients[index].Surname;
            Email.Text = Clients[index].Email;
            Phone.Text = Clients[index].Phone;
            Gender.Text = Clients[index].GenderId.ToString();

            PrevButton.IsEnabled = index != 0;
            NextButton.IsEnabled = index != Clients.Count - 1;

            (Gender.ToolTip as ToolTip).Content = Clients[index].GenderDescription;
        }

        private void ClientForm_OnLoaded(object sender, RoutedEventArgs e)
        {
            Clients = new List<Client>();
            // ORM-3 заполнение коллекции
            try
            {
                SqlDataReader reader = DataBaseConnector.GetReader(
                    "SELECT C.id, C.name, surname, email, phone, genderId, G.description FROM Clients C JOIN Genders G ON C.GenderID = G.Id");
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
            // Отображаем на форме данные о размере коллекции Clients
            
            ShowClient();
        }
    }

    public class Client  // класс ORM - отображение (mapping) таблицы Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public string GenderDescription { get; set; }
    }
}

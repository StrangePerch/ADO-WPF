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

namespace Barber.Windows
{
    /// <summary>
    /// Interaction logic for JournalWindow.xaml
    /// </summary>
    public partial class JournalWindow : Window
    {
        private BarberShop barberShop;
        
        public JournalWindow()
        {
            InitializeComponent();
        }

        private void JournalWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            barberShop = DataBaseConnector.GetBarberShop();

            var queryClients
                = from client in barberShop.Clients
                select client;

            var queryGenders = from gender in barberShop.Genders
                select gender;

            var clientsAmount = queryClients.Count();
            var gendersAmount = queryGenders.Count();

            MessageBox.Show($"Amount of Clients: {clientsAmount}\n" +
                                       $"Amount of Genders: {gendersAmount}", "Amount");

            String str = "";
            foreach (var c in queryClients)
            {
                str += c.FullName + " " + c.Email + " " + c.Phone + "\n";
            }

            MessageBox.Show(str, "Clients");


            str = "";
            foreach (var g in queryGenders)
            {
                if(g.Description.Length < 100)
                    str += g.Name + " - " + g.Description + "\n";
                else
                    str += g.Name + " - " + g.Description.Substring(0, 100) + "..." + "\n";

            }

            MessageBox.Show(str, "Genders");
        }
    }
}

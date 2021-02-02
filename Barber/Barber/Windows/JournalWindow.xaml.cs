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

            var query
                = from client in barberShop.Clients
                select client;

            String str = "";
            foreach (var c in query)
            {
                str += c.FullName + " " + c.Email + " " + c.Phone + "\n";
            }

            MessageBox.Show(str, "Message");
        }
    }
}

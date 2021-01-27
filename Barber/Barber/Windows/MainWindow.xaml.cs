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
using Barber.Windows;

namespace Barber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Main.Start();
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Main.Finish();
        }

        private void GendersButton_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            GendersWindow window = new GendersWindow();
            window.ShowDialog();
        }

        private void BarbersButton_OnClick(object sender, RoutedEventArgs e)
        {
            BarbersWindow window = new BarbersWindow();
            window.ShowDialog();
        }

        private void ClientsButton_OnClick(object sender, RoutedEventArgs e)
        {
            ClientsWindow window = new ClientsWindow();
            window.ShowDialog();
        }

        private void AddClientButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddNewClient window = new AddNewClient();
            window.ShowDialog();
        }
    }
}

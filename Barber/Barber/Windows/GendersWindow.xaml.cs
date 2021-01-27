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

namespace Barber
{
    /// <summary>
    /// Interaction logic for GendersWindow.xaml
    /// </summary>
    public partial class GendersWindow : Window
    {
        public GendersWindow()
        {
            InitializeComponent();
        }

        private void GendersWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataBaseConnector.DataGridConnect(GendersGrid, "SELECT * FROM Genders");
        }
    }
}

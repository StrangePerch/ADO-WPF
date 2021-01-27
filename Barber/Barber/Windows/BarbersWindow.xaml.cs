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
    /// Interaction logic for BarbersWindow.xaml
    /// </summary>
    public partial class BarbersWindow : Window
    {
        public BarbersWindow()
        {
            InitializeComponent();
        }

        private void BarbersWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataBaseConnector.DataGridConnect(BarbersGrid, "SELECT * FROM Barbers");
            BarbersGrid.Columns[0].IsReadOnly = true;
            CountTextBox.Text = DataBaseConnector.Count().ToString();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataBaseConnector.Save();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

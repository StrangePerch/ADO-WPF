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
        //private BarberShop barberShop;
        
        public JournalWindow()
        {
            InitializeComponent();
        }

        private void JournalWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //barberShop = DataBaseConnector.GetBarberShop();

            //var jor =
            //    from J in barberShop.Journal
            //    join B in barberShop.Barbers on J.id_barber equals B.Id
            //    join C in barberShop.Clients on J.id_client equals C.Id
            //    select new { J, B, C };


            //foreach (var client in barberShop.Clients)
            //{
            //    ClientBox.Items.Add(client);
            //}

            //foreach (var barber in barberShop.Barbers)
            //{
            //    BarberBox.Items.Add(barber);
            //}
        }

        //private void OnClick(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show((sender as TextBlock).Tag.ToString());
        //}

        //private void JournalWindow_OnLoaded2(object sender, RoutedEventArgs e)
        //{
        //    barberShop = DataBaseConnector.GetBarberShop();

        //    //var queryClients
        //    //    = from client in barberShop.Clients
        //    //    select client;

        //    //var queryGenders = from gender in barberShop.Genders
        //    //    select gender;

        //    //var clientsAmount = queryClients.Count();
        //    //var gendersAmount = queryGenders.Count();

        //    //MessageBox.Show($"Amount of Clients: {clientsAmount}\n" +
        //    //                           $"Amount of Genders: {gendersAmount}", "Amount");

        //    //String str = "";
        //    //foreach (var c in queryClients)
        //    //{
        //    //    str += c.FullName + " " + c.Email + " " + c.Phone + "\n";
        //    //}

        //    //MessageBox.Show(str, "Clients");


        //    //str = "";
        //    //foreach (var g in queryGenders)
        //    //{
        //    //    if(g.Description.Length < 100)
        //    //        str += g.Name + " - " + g.Description + "\n";
        //    //    else
        //    //        str += g.Name + " - " + g.Description.Substring(0, 100) + "..." + "\n";

        //    //}

        //    //MessageBox.Show(str, "Genders");
            
        //    //var joinQuery = from c in  barberShop.Clients
        //    //                 join g in barberShop.Genders on c.GenderId equals g.Id
        //    //                 where c.Id < 10 && g.Id < 100
        //    //                 select new Mixed { Name = c.Name, Gender = g .Name };

        //    StringBuilder sb = new StringBuilder();

        //    //foreach (Mixed obj in joinQuery)
        //    //{
        //    //    sb.Append(obj.Name);
        //    //    sb.Append(' ');
        //    //    sb.Append(obj.Gender);
        //    //    sb.Append('\n');
        //    //}

        //    ////MessageBox.Show(sb.ToString());


        //    foreach (var c in barberShop.Clients)
        //    {
        //        sb.Append(c.Name);
        //        sb.Append(' ');
        //        sb.Append(c.Surname);
        //        sb.Append(' ');
        //        try
        //        {

        //            sb.Append(barberShop
        //                .Genders
        //                .First(g => g.Id == c.GenderId)
        //                .Name
        //            );
        //            sb.Append(' ');
        //        }
        //        catch (Exception exception)
        //        {
        //            sb.Append("- ");
        //        }
        //    }

        //    MessageBox.Show(sb.ToString());

        //}
    }

    //public class Mixed
    //{
    //    public string Name;
    //    public string Gender;
    //}
}

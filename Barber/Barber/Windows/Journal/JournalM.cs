using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Barber.Windows
{
    public class JournalM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BarberShop barberShop;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public JournalM()
        {
            LoadList();
        }

        private ObservableCollection<Journal_Item> _journalList;

        public ObservableCollection<Journal_Item> JournalList
        {
            get => _journalList;
            set
            {
                _journalList = value;
                OnPropertyChanged("JournalList");
            }
        }

        private List<LinqClient> _clients;
        public List<LinqClient> Clients
        {
            get => _clients;

            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private List<LinqBarber> _barbers;
        public List<LinqBarber> Barbers
        {
            get => _barbers;

            set
            {
                _barbers = value;
                OnPropertyChanged("Barbers");
            }
        }

        private void LoadList()
        {
            if(barberShop == null)
                barberShop = DataBaseConnector.GetBarberShop();

            JournalList = new ObservableCollection<Journal_Item>();
            
            var jor =
                from J in barberShop.Journal
                join B in barberShop.Barbers on J.id_barber equals B.Id
                join C in barberShop.Clients on J.id_client equals C.Id
                select new { J, B, C };

            var clients = from C in barberShop.Clients select new {C};
            var barbers = from B in barberShop.Barbers select new {B};

            Barbers = new List<LinqBarber>();

            foreach (var barber in barbers.ToList())
            {
                Barbers.Add(barber.B);
            }

            Clients = new List<LinqClient>();

            foreach (var client in clients.ToList())
            {
                Clients.Add(client.C);
            }
            
            foreach (var j in jor)
            {
                JournalList.Add
                    (
                        new Journal_Item()
                        {
                            Client_Name = j.C.Name,
                            Client_Surname = j.C.Surname,
                            Barber_Name = j.B.Name,
                            Barber_Surname = j.B.Surname,
                            Moment = j.J.moment,
                            journal = j.J
                        }
                    );
            }
        }


        public void AddJournal(LinqClient client, LinqBarber barber, DateTime moment)
        {
            LinqJournal journal = new LinqJournal()
            {
                id_barber = barber.Id,
                id_client = client.Id,
                moment = moment
            };
            barberShop.Journal.InsertOnSubmit(journal);

            barberShop.SubmitChanges();

            JournalList.Add
            (
                new Journal_Item()
                {
                    Client_Name = client.Name,
                    Client_Surname = client.Surname,
                    Barber_Name = barber.Name,
                    Barber_Surname = barber.Surname,
                    Moment = moment,
                    journal = journal
                }
            );
            
        }

        public void DeleteJournal(Journal_Item item)
        {
            JournalList.Remove(item);
            
            barberShop.Journal.DeleteOnSubmit(item.journal);
            
            barberShop.SubmitChanges();
        }
    }
}
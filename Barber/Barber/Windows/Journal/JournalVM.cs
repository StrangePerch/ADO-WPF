using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Barber.Windows
{
    public class JournalVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private LinqClient _client;
        public LinqClient Client
        {
            get => _client;
            set
            {
                _client = value;
                OnPropertyChanged("Client");
            }
        }

        private LinqBarber _barber;
        public LinqBarber Barber
        {
            get => _barber;
            set
            { 
                _barber = value; 
                OnPropertyChanged("Barber");
            }
        }

        private DateTime _moment;

        public DateTime Moment
        {
            get => _moment;

            set
            {
                _moment = value; 
                OnPropertyChanged("Moment");
            }
        }

        private Journal_Item _selectedItem;

        public Journal_Item SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;
                OnPropertyChanged("Moment");
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public BarberShop barberShop;
        
        public JournalVM()
        {
            barberShop = DataBaseConnector.GetBarberShop();

            AddCommand = new Command(Add, CanAdd);
            ResetCommand = new Command(Reset, True);
            DeleteCommand = new Command(Delete, True);
            Moment = DateTime.Today;
        }

        public void Delete(object sender)
        {
            if (SelectedItem == null)
                return;
            _model.DeleteJournal(SelectedItem);
        }

        public void Add(object sender)
        {
            _model.AddJournal(Client, Barber, Moment);
        }

        public bool CanAdd(object sender)
        {
            if (Barber == null) return false;
            if (Client == null) return false;
            return true;
        }

        public void Reset(object sender)
        {
            Barber = null;
            Client = null;
            Moment = DateTime.Today;
        }

        public bool True(object sender)
        {
            return true;
        }

        public ObservableCollection<Journal_Item> JournalList => _model.JournalList;

        public List<LinqClient> Clients => _model.Clients;

        public List<LinqBarber> Barbers => _model.Barbers;

        

        private readonly JournalM _model = new JournalM();
    }
    
    
}
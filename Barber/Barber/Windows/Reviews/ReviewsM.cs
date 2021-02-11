using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace Barber.Windows.Reviews
{
    public class ReviewsM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BarberShop barberShop;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReviewsM()
        {
            _reviews = new ObservableCollection<ReviewItem>();
            barberShop = DataBaseConnector.GetBarberShop();
            LoadList();
        }
        
        List<LinqBarber> _barberList;
        public List<LinqBarber> BarberList
        {
            get => _barberList;
            set
            {
                _barberList = value;
                OnPropertyChanged("BarberList");
            }
        }

        private ObservableCollection<ReviewItem> _reviews;
        public ObservableCollection<ReviewItem> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged("Reviews");
            }
        }

        private string _info;
        public string Info
        {
            get => _info;
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        private void LoadList()
        {
            BarberList = barberShop.Barbers.ToList();
        }
        
        

        public void GetReviews(int barber_id)
        {
            //var temp =
            //    from R in barberShop.Reviews
            //    join J in barberShop.Journal on R.JournalId equals J.id
            //    where J.id_client == client_id
            //    select new {R.Text, R.Id, R.Rating, J.id_client, J.id_barber};


            //var table =
            //    from T in temp
            //    join C in barberShop.Clients on T.id_client equals C.Id
            //    select new {T.Id, T.Text, T.Rating, C.FullName};

            var table =
                from R in barberShop.Reviews
                join J in barberShop.Journal on R.JournalId equals J.id
                join C in barberShop.Clients on J.id_client equals C.Id
                where J.id_barber == barber_id
                select new { R.Text, R.Id, R.Rating, C.FullName };

            _reviews.Clear();

            if (!table.Any()) return;

            int total = 0;
            
            foreach (var obj in table)
            {
                Reviews.Add(
                    new ReviewItem()
                    {
                        Id = obj.Id,
                        Text = obj.Text,
                        Rating = obj.Rating,
                        Client = obj.FullName
                    }
                    );
                total += obj.Rating;
            }

            Info = $"Avg: {total / Reviews.Count}";

        }
    }
}
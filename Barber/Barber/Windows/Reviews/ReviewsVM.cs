using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Barber.Windows.Reviews
{
    public class ReviewsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly ReviewsM _model = new ReviewsM();

        public ReviewsVM()
        {
        }

        private LinqBarber _selectedBarber;

        public LinqBarber SelectedBarber
        {
            get => _selectedBarber;
            
            set
            {
                _selectedBarber = value;
                _model.GetReviews(SelectedBarber.Id);
                OnPropertyChanged("SelectedBarber");
            }
        }

        public ICommand RefreshCommand;

        public List<LinqBarber> Barbers => _model.BarberList;

        public ObservableCollection<ReviewItem> Reviews => _model.Reviews;

        public string Info => _model.Info;

    }
}
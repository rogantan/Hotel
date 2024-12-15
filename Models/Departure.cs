using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Departure : NotifyProperty
    {
        private int _id;
        private Reservation _reservation;
        private DateOnly _departureDate;

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public Reservation Reservation
        {
            get => _reservation;
            set
            {
                if (_reservation != value)
                {
                    _reservation = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateOnly DepartureDate
        {
            get => _departureDate;
            set
            {
                if (_departureDate != value)
                {
                    _departureDate = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

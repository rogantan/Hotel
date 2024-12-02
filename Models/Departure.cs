using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Departure : NotifyProperty
    {
        //public int Id { get; set; }
        private Reservation _reservation;
        private DateTime _departureDate;

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
        public DateTime DepartureDate
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

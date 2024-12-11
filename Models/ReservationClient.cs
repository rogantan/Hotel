using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ReservationClient : NotifyProperty
    {
        private int _id;
        private Client _client;
        private Reservation _reservation;

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
        public Client Client
        {
            get => _client;
            set
            {
                if (value != _client)
                {
                    _client = value;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ReservationClient : NotifyProperty
    {
        //public int Id { get; set; }
        private Client _client;
        private Reservation _reservation;

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

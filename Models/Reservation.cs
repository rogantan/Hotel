using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Reservation : NotifyProperty
    {
        private int _id;
        private Room _room;
        private Employee _employee;
        private DateOnly _reservationDate;
        private DateOnly _checkinDate;

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
        public Room Room
        {
            get => _room;
            set
            {
                if (_room != value)
                {
                    _room = value;
                    OnPropertyChanged();
                }
            }
        }
        public Employee Employee
        {
            get => _employee;
            set
            {
                if (_employee != value)
                {
                    _employee = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateOnly ReservationDate
        {
            get => _reservationDate;
            set
            {
                if (_reservationDate != value)
                {
                    _reservationDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateOnly CheckinDate
        {
            get => _checkinDate;
            set
            {
                if (_checkinDate != value)
                {
                    _checkinDate = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

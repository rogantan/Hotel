using Hotel.Models;
using Hotel.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    class PagesViewModel
    {
        MyDatabase db = MyDatabase.getInstance();
        public ObservableCollection<Client> Clients { get => db.Clients.Local.ToObservableCollection(); }
        public ObservableCollection<Discount> Discounts { get => db.Discounts.Local.ToObservableCollection(); }
        public ObservableCollection<Service> Services { get => db.Services.Local.ToObservableCollection(); }
        public ObservableCollection<ReservationClientDeparture> ReservationsClients { get; set; }
        public ObservableCollection<CheckInService> CheckInsServices { get => db.CheckInsServices.Local.ToObservableCollection(); }
        public ObservableCollection<Room> Rooms { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public PagesViewModel()
        {
            Rooms = db.Rooms.Local.ToObservableCollection();
            ReservationsClients = Join();
            SearchCommand = new RelayCommand(Search);
        }


        public ObservableCollection<ReservationClientDeparture> Join()
        {
            using (MyDatabase db = new MyDatabase())
            {
                // Используем Select для создания объединенной модели
                var result = (
                    from reservation in db.Reservations
                    join reservation_client in db.ReservationsClients on reservation.Id equals reservation_client.Reservation.Id
                    join departure in db.Departures on reservation.Id equals departure.Reservation.Id
                    select new ReservationClientDeparture
                    {
                        Id = reservation.Id,
                        Fio = reservation_client.Client.Fio,
                        Passport = reservation_client.Client.Passport,
                        RoomId = reservation.Room.Id,
                        Price = reservation.Room.Price,
                        CheckInDate = reservation.CheckinDate,
                        DepartureDate = departure.DepartureDate
                    }).ToList();
                return new ObservableCollection<ReservationClientDeparture>(result);
            }
            
        }

        void Search(object o)
        {
            //var CheckInDate = db.Reservations.Where()
        }
    }
}

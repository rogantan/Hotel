using Hotel.Models;
using Hotel.Models.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    class PagesViewModel : NotifyProperty
    {
        MyDatabase db = MyDatabase.getInstance();
        public ObservableCollection<Client> Clients { get => db.Clients.Local.ToObservableCollection(); }
        public ObservableCollection<Discount> Discounts { get => db.Discounts.Local.ToObservableCollection(); }
        public ObservableCollection<Service> Services { get => db.Services.Local.ToObservableCollection(); }
        public ObservableCollection<ReservationClientDeparture> ReservationsClients { get; set; }
        public ObservableCollection<CheckInService> CheckInsServices { get => db.CheckInsServices.Local.ToObservableCollection(); }
        public RelayCommand SearchCommand { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        private List<Room> _rooms;
        public List<Room> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms)); // Уведомление об изменении свойства
            }
        }
        public PagesViewModel()
        {
            Rooms = db.Rooms.Local.ToList();
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
            NpgsqlParameter param = new NpgsqlParameter("@date1", DateOnly.FromDateTime(FirstDate));
            NpgsqlParameter param1 = new NpgsqlParameter("@date2", DateOnly.FromDateTime(SecondDate));
            var rooms = db.Rooms.FromSqlRaw("""
                SELECT * 
                FROM "Rooms" 
                WHERE "Id" NOT IN (
                    SELECT "RoomId" 
                    FROM "Reservations"
                    JOIN "Departures" ON "Reservations"."Id" = "Departures"."ReservationId"
                    WHERE (
                        ("Reservations"."CheckinDate" <= @date2 AND "Departures"."DepartureDate" >= @date1)
                    )
                );
                
                """, param, param1).ToList();
            Console.WriteLine(rooms);
            Rooms = rooms;
        }
    }
}

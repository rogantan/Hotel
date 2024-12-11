using Hotel.Models;
using Hotel.Models.Data;
using Hotel.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    class AddReservationViewModel
    {
        MyDatabase db = new MyDatabase();
        public AddReservationViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
            AddClientsCommand = new RelayCommand(AddClient);
            SaveReservationCommand = new RelayCommand(SaveReservation);
            SaveDateCommand = new RelayCommand(SaveDate);
        }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand SaveReservationCommand { get; set; }
        public RelayCommand AddClientsCommand { get; set; }
        public RelayCommand SaveDateCommand { get; set; }

        public string RoomId { get; set; }
        public string EmployeeLogin { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime DepartureDate { get; set; }

        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddReservationWindow>().FirstOrDefault()?.Close();
        }

        void AddClient(object o)
        {
            AddClientReservationWindow w = new AddClientReservationWindow(EmployeeLogin);
            w.ShowDialog();
        }

        void SaveReservation(object o)
        {
            if (string.IsNullOrEmpty(RoomId) || string.IsNullOrEmpty(EmployeeLogin))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            using (MyDatabase db = MyDatabase.getInstance())
            {
                var room = db.Rooms.Find(int.Parse(RoomId));
                var employee = db.Employees.FirstOrDefault(e => e.Login == EmployeeLogin);
                if (room == null || employee == null)
                {
                    MessageBox.Show("Одна или несколько записей не найдены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var reservation = new Reservation
                {
                    Room = room,
                    Employee = employee,
                    ReservationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    CheckinDate = DateTime.SpecifyKind(CheckInDate, DateTimeKind.Utc)
                };
                db.Reservations.Add(reservation);
                db.SaveChanges();
                MessageBox.Show("Бронь успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        void SaveDate(object o)
        {
            var employee = db.Employees.Where(e => e.Login == EmployeeLogin).FirstOrDefault();
            var reservation = db.Reservations.Where(r => r.Employee == employee).OrderByDescending(e => e.Id).FirstOrDefault();
            if (reservation != null)
            {
                var departure = new Departure
                {
                    Reservation = reservation,
                    DepartureDate = DateTime.SpecifyKind(DepartureDate, DateTimeKind.Utc)
                };
                db.Departures.Add(departure);
                db.SaveChanges();
                MessageBox.Show("Дата выезда успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

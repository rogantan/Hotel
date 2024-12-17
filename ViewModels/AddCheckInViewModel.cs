using Hotel.Models;
using Hotel.Models.Data;
using Hotel.Views;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    class AddCheckInViewModel
    {

        public AddCheckInViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
            AddServiceCommand = new RelayCommand(AddService);
            SaveCheckInCommand = new RelayCommand(SaveCheckIn);
        }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand SaveCheckInCommand { get; set; }
        public RelayCommand AddServiceCommand { get; set; }

        public string ReservationId { get; set; }
        public string EmployeeLogin { get; set; }
        public string DiscountId { get; set; }



        void Exit(object o)
        {
            if (!string.IsNullOrWhiteSpace(ReservationId) && !string.IsNullOrWhiteSpace(EmployeeLogin) && !string.IsNullOrEmpty(DiscountId))
            {
                using (MyDatabase db = MyDatabase.getInstance())
                {
                    var reservation = db.Reservations.Find(int.Parse(ReservationId));
                    //MessageBox.Show($"{reservation.Room}");
                    var checkin = db.CheckIns.FirstOrDefault(c => c.Reservation.Id == reservation.Id);
                    //MessageBox.Show($"{checkin.Id}");
                    if (checkin != null && reservation != null)
                    {
                        var ServiceSumma = db.CheckInsServices.Where(cis => cis.CheckIn == checkin).Include(cis => cis.Service).Sum(cis => cis.Service.Price);
                        var departureDate = (from Reserv in db.Reservations
                                             join Departure in db.Departures on Reserv.Id equals Departure.Reservation.Id
                                             where Reserv.Id == reservation.Id
                                             select Departure.DepartureDate).SingleOrDefault();
                        var DiscountSize = checkin.Discount.Size;
                        var RoomPrice = reservation.Room.Price;
                        var checkinDate = reservation.CheckinDate;
                        var raz = departureDate.DayNumber - checkinDate.DayNumber;
                        var Itog = (RoomPrice - (DiscountSize * RoomPrice / 100)) * raz + ServiceSumma;
                        MessageBox.Show($"Сумма услуг - {ServiceSumma}\nСкидка - {DiscountSize}\n" +
                            $"Цена номера - {RoomPrice}\nДата заселения {checkinDate}\nДата в {departureDate}\n" +
                            $"Итоговая сумма - {Itog}", "Чек");

                    }
                }
                  
            }
            Application.Current.Windows.OfType<AddCheckInWindow>().FirstOrDefault()?.Close();
        }


        void AddService(object o)
        {
            AddServiceCheckInWindow w = new AddServiceCheckInWindow(EmployeeLogin);
            w.ShowDialog();
        }

        void SaveCheckIn(object o)
        {
            if (string.IsNullOrWhiteSpace(ReservationId) || string.IsNullOrWhiteSpace(EmployeeLogin) || string.IsNullOrEmpty(DiscountId))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (MyDatabase db = new MyDatabase())
            {
                var reservation = db.Reservations.Find(int.Parse(ReservationId));
                var employee = db.Employees.FirstOrDefault(e => e.Login == EmployeeLogin);
                var discount = db.Discounts.Find(int.Parse(DiscountId));
                if (reservation == null || employee == null || discount == null)
                {
                    MessageBox.Show("Одна или несколько записей не найдены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var checkIn = new CheckIn
                {
                    Reservation = reservation,
                    Employee = employee,
                    Discount = discount
                };
                db.CheckIns.Add(checkIn);
                db.SaveChanges();
                MessageBox.Show("Заселение успешно добавлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // message box для общей суммы
                //var totalPrice = db.Services.Where(s => db.CheckInsServices.Any(c => c.CheckInId == 2)).Sum(s => s.Price);


            }

        }
    }

}
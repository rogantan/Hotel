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
        public string EmployeeLogin {  get; set; }
        public string DiscountId { get; set; }



        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddCheckInWindow>().FirstOrDefault()?.Close();
        }


        void AddService(object o)
        {
            AddServiceCheckInWindow w = new AddServiceCheckInWindow(EmployeeLogin);
            w.ShowDialog();
        }

        void SaveCheckIn(object o)
        {
            if (string.IsNullOrWhiteSpace(ReservationId) || string.IsNullOrWhiteSpace(EmployeeLogin))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (MyDatabase db = MyDatabase.getInstance())
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
            }

        }
    }
}

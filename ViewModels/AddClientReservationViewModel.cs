using Hotel.Models;
using Hotel.Models.Data;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    class AddClientReservationViewModel
    {
        
        public AddClientReservationViewModel(string employeeLogin)
        {
            this.EmployeeLogin = employeeLogin;
            ExitCommand = new RelayCommand(Exit);
            SaveClientCommand = new RelayCommand(SaveClient);
        }

        public RelayCommand ExitCommand { get; set; }
        public RelayCommand SaveClientCommand {  get; set; }

        public string EmployeeLogin { get; set; }
        public string ClientId { get; set; }

        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddClientReservationWindow>().FirstOrDefault()?.Close();
        }

        void SaveClient(object o)
        {
            using (MyDatabase db = new MyDatabase())
            {
                var employee = db.Employees.Where(e => e.Login == EmployeeLogin).FirstOrDefault();
                var reservation = db.Reservations.Where(r => r.Employee == employee).OrderByDescending(e => e.Id).FirstOrDefault();
                var client = db.Clients.Find(int.Parse(ClientId));
                if (employee != null && reservation != null && client != null)
                {
                    var reservationclient = new ReservationClient
                    {
                        Reservation = reservation,
                        Client = client
                    };
                    db.ReservationsClients.Add(reservationclient);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно загружены");
                    Application.Current.Windows.OfType<AddClientReservationWindow>().FirstOrDefault()?.Close();
                }
                else
                    MessageBox.Show($"Данные не найдены");
            }
        }
    }
}

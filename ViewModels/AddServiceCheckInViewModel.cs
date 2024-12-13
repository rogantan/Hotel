using Hotel.Models;
using Hotel.Models.Data;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    class AddServiceCheckInViewModel
    {
        MyDatabase db = MyDatabase.getInstance();
        public AddServiceCheckInViewModel(string employeeLogin)
        {
            this.EmployeeLogin = employeeLogin;
            ExitCommand = new RelayCommand(Exit);
            SaveServiceCommand = new RelayCommand(SaveService);
        }

        public ObservableCollection<Service> Services { get => db.Services.Local.ToObservableCollection(); }

        public RelayCommand ExitCommand {  get; set; }
        public RelayCommand SaveServiceCommand {  get; set; }


        public string EmployeeLogin { get; set; }
        public string ServiceId { get; set; }



        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddServiceCheckInWindow>().FirstOrDefault()?.Close();
        }

        void SaveService(object o)
        {
            using (MyDatabase db = new MyDatabase())
            {
                var employee = db.Employees.Where(e => e.Login == EmployeeLogin).FirstOrDefault();
                var checkin = db.CheckIns.Where(r => r.Employee == employee).OrderByDescending(e => e.Id).FirstOrDefault();
                var service = db.Services.Find(int.Parse(ServiceId));
                if (employee != null && checkin != null && service != null)
                {
                    var servicecheckin = new CheckInService
                    {
                        CheckIn = checkin,
                        Service = service
                    };
                    db.CheckInsServices.Add(servicecheckin);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно загружены");
                    Application.Current.Windows.OfType<AddServiceCheckInWindow>().FirstOrDefault()?.Close();
                }
                else
                    MessageBox.Show($"Данные не найдены");
            }
        }
    }
}

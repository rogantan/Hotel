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
    public class AddClientViewModel : NotifyProperty
    {
        MyDatabase db = MyDatabase.getInstance();
        public AddClientViewModel()
        {
            CancelCommand = new RelayCommand(Exit);
            SaveCommand = new RelayCommand(Save);
        }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set;}
        public string FIO {  get; set; }
        public string Passport { get; set; }
        public string Phone {  get; set; }
        public DateTime BirthDate { get; set; }

        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddClientWindow>().FirstOrDefault()?.Close();
        }

        void Save(object o)
        {
            if (string.IsNullOrEmpty(FIO))
                MessageBox.Show("Не введено ФИО", "Ошибка");
            else if (string.IsNullOrEmpty(Passport))
                MessageBox.Show("Не введены паспортные данные", "Ошибка");
            else if (string.IsNullOrEmpty(Phone))
                MessageBox.Show("Не введен номер телефона", "Ошибка");
            else
            {
                Client client = new Client();
                client.Fio = FIO;
                client.Passport = Passport;
                client.Phone = Phone;
                client.BirthDate = DateTime.SpecifyKind(BirthDate, DateTimeKind.Utc);
                db.Clients.Add(client);
                db.SaveChanges();
                MessageBox.Show($"Данные успешно добавлены!");
                Application.Current.Windows.OfType<AddClientWindow>().FirstOrDefault()?.Close();
            }
        }
    }
}

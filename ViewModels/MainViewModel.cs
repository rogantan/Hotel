using Hotel.Models.Data;
using Hotel.Models;
using Hotel.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hotel.Views;
using System.Windows.Controls;

namespace Hotel.ViewModels
{
    public class MainViewModel : NotifyProperty
    {
        public MyDatabase db = MyDatabase.getInstance();

        private Page Clients;
        private Page Reservations;


        private Page _currentPage;

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        public RelayCommand Vihod { get; set; }
        public RelayCommand MinCommand { get; set; }
        public RelayCommand MaxCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand AddReservationCommand { get; set; }
        public RelayCommand AddCheckInCommand { get; set; }
        public RelayCommand ClientsCommand { get; set; }
        public RelayCommand ReservationsCommand { get; set; }
        public RelayCommand RoomsCommand { get; set; }
        public RelayCommand CheckInsCommand { get; set; }
        public RelayCommand DiscountsCommand { get; set; }
        public RelayCommand ServicesCommand { get; set; }
        public MainViewModel()
        {
            Vihod = new RelayCommand(Exit);
            MinCommand = new RelayCommand(Mini);
            MaxCommand = new RelayCommand(Maxi);
            BackCommand = new RelayCommand(Back);
            AddClientCommand = new RelayCommand(AddClient);
            AddReservationCommand = new RelayCommand(AddReservation);
            AddCheckInCommand = new RelayCommand(AddCheckIn);

            CurrentPage = new PageClients();
            //Clients = Page
            ClientsCommand = new RelayCommand(SeeClients);
        }

        void Exit(object o)
        {
            Application.Current.Shutdown();
        }

        void Mini(object o)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        void Maxi(object o)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            else
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        void Back(object o)
        {
            Authorization w = new Authorization();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = w;
            Application.Current.MainWindow.Show();
        }
        
        void AddClient(object o)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
        }

        void AddReservation(object o)
        {
            AddReservationWindow addReservationWindow = new AddReservationWindow();
            addReservationWindow.ShowDialog();
        }

        void AddCheckIn(object o)
        {
            AddCheckInWindow addCheckInWindow = new AddCheckInWindow();
            addCheckInWindow.ShowDialog();
        }


        void SeeClients(object o)
        {
            CurrentPage = new PageClients();
            MessageBox.Show("rjhr");
        }
    }
}

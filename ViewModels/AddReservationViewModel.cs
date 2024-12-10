using Hotel.Models;
using Hotel.Views;
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
        public AddReservationViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
        }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand SaveReservationCommand { get; set; }
        public RelayCommand AddClientsCommand { get; set; }
        public RelayCommand SaveDateCommand { get; set; }

        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddReservationWindow>().FirstOrDefault()?.Close();
        }
    }
}

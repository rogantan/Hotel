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
    class AddCheckInViewModel
    {
        public AddCheckInViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
        }
        public RelayCommand ExitCommand { get; set; }





        void Exit(object o)
        {
            Application.Current.Windows.OfType<AddCheckInWindow>().FirstOrDefault()?.Close();
        }
    }
}

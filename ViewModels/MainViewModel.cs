using Hotel.Models.Data;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels
{
    public class MainViewModel
    {
        public MyDatabase db = MyDatabase.getInstance();
        public RelayCommand Vihod { get; set; }
        public MainViewModel()
        {
            Vihod = new RelayCommand(Exit);
        }

        void Exit(object o)
        {
            //Application.Current.MainWindow.b
            Application.Current.Shutdown();
        }
    }
}

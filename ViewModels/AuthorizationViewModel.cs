using Hotel.Models.Data;
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
    public class AuthorizationViewModel : NotifyProperty
    {
        public MyDatabase db = MyDatabase.getInstance();
        public string Login { get; set; }
        public string Password { get; set; }

        public RelayCommand LogInCommand { get; set; }
        public AuthorizationViewModel()
        {
            ExitCommand = new RelayCommand(Exit);
            LogInCommand = new RelayCommand(LogIn);
            MinCommand = new RelayCommand(Mini);
            MaxCommand = new RelayCommand(Maxi);
        }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand MinCommand { get; set; }
        public RelayCommand MaxCommand { get; set; }
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
        void LogIn(object o)
        {
            var u = db.Employees.Where(x => x.Login == Login && x.Password == Password).FirstOrDefault();
            if (u != null)
            {
                MainWindow w = new MainWindow();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = w;
                Application.Current.MainWindow.Show();
            }
            else
                MessageBox.Show("Incorrect login/password");
        }
    }
}

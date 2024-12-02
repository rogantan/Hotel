using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Employee : NotifyProperty
    {
        private int _id;
        private string _login;
        private string _password;
        private string _fio;

        public int Id 
        { 
            get => _id; 
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Fio
        {
            get => _fio;
            set
            {
                if (value != _fio)
                {
                    _fio = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

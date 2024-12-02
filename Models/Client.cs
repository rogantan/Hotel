using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Client : NotifyProperty
    {
        private int _id;
        private string _fio;
        private DateTime _birthDate;
        private string _passport;
        private string _phone;

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
        public string Fio
        {
            get => _fio;
            set
            {
                if (_fio != value)
                {
                    _fio = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Passport
        {
            get => _passport;
            set
            {
                if (value != _passport)
                {
                    _passport = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

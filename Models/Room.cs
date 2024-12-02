using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Room : NotifyProperty
    {
        private int _id;
        private string _comfort;
        private int _price;

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
        public string Comfort
        {
            get => _comfort;
            set
            {
                if (_comfort != value)
                {
                    _comfort = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged();
                }

            }
        }
    }
}

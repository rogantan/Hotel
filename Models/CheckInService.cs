using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class CheckInService : NotifyProperty
    {
        private CheckIn _checkin;
        private Service _service;

        public CheckIn CheckIn
        {
            get => _checkin;
            set
            {
                if (_checkin != value)
                {
                    _checkin = value;
                    OnPropertyChanged();
                }
            }
        }
        public Service Service
        {
            get => _service;
            set
            {
                if (_service != value)
                {
                    _service = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    class ReservationClientDeparture
    {
        public int Id { get; set; }
        public string Fio {  get; set; }
        public string Passport { get; set; }
        public int RoomId { get; set; }
        public int Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}

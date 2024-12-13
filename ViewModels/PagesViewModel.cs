using Hotel.Models;
using Hotel.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    class PagesViewModel
    {
        MyDatabase db = MyDatabase.getInstance();
        public ObservableCollection<Client> Clients { get => db.Clients.Local.ToObservableCollection(); }
        public ObservableCollection<Discount> Discounts { get => db.Discounts.Local.ToObservableCollection(); }
        public ObservableCollection<Service> Services { get => db.Services.Local.ToObservableCollection(); }
        public ObservableCollection<ReservationClient> ReservationsClients { get => db.ReservationsClients.Local.ToObservableCollection(); }
        public ObservableCollection<CheckInService> CheckInsServices { get => db.CheckInsServices.Local.ToObservableCollection(); }
        public ObservableCollection<Room> Rooms { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public PagesViewModel()
        {
            Rooms = db.Rooms.Local.ToObservableCollection();
            SearchCommand = new RelayCommand(Search);
        }


        void Search(object o)
        {
            //var CheckInDate = db.Reservations.Where()
        }
    }
}

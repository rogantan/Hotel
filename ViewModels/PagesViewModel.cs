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
        public PagesViewModel()
        {

        }
    }
}

using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReservations.xaml
    /// </summary>
    public partial class PageReservations : Page
    {
        public PageReservations()
        {
            InitializeComponent();
            DataContext = new PagesViewModel();
        }
    }
}

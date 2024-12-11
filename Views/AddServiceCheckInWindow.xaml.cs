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
using System.Windows.Shapes;
using Hotel.ViewModels;

namespace Hotel.Views
{
    /// <summary>
    /// Логика взаимодействия для AddServiceCheckInWindow.xaml
    /// </summary>
    public partial class AddServiceCheckInWindow : Window
    {
        public AddServiceCheckInWindow(string employeeLogin)
        {
            InitializeComponent();
            DataContext = new AddServiceCheckInViewModel(employeeLogin);
        }
    }
}

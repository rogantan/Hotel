﻿using System;
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
    /// Логика взаимодействия для AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        public AddReservationWindow()
        {
            InitializeComponent();
            DataContext = new AddReservationViewModel();
        }
    }
}

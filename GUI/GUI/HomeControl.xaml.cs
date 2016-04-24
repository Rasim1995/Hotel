using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelClassLibrary;
using System.Data;
using System.Collections;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {
		DataLayer data = new DataLayer();
        public HomeControl()
        {
            InitializeComponent();
            dgvRooms.ItemsSource = data.GetAllRooms();
			
			

		}

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationForm au = new AuthorizationForm();
            au.ShowDialog();
        }

    }
}

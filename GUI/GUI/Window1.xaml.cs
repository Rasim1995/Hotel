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
using System.Windows.Shapes;
using HotelClassLibrary;

namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AuthorizationForm : Window
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

		void Authorization()
		{
			try
			{
				Hotel.Authorization(txbxLogin.Text, txbxPassword.Password);
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnEnter_Click(object sender, RoutedEventArgs e)
		{
			Authorization();
		}
	}
}

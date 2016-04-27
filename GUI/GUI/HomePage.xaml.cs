using HotelClassLibrary;
using System;
using System.Collections;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;


namespace GUI
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private ArrayList listRooms;
        
        public HomePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDgRooms();
            txbxMinCost.TextChanged += TxbxMinCost_TextChanged;
            txbxMaxCost.TextChanged += TxbxMaxCost_TextChanged;
            chbxNumberOfRooms.SelectionChanged += ChbxNumberOfRooms_SelectionChanged;
            chbxNumberOfSeats.SelectionChanged += ChbxNumberOfSeats_SelectionChanged;
        }


        private void LoadDgRooms()
        {
            listRooms = DataLayer.GetAllRooms();           
            dgRooms.ItemsSource = listRooms;
        }

        private void SearchRoomsByCategory()
        {
            if (lsbxCategories.SelectedIndex == -1)
                return;

            listRooms = DataLayer.GetAllRooms();

            for(int i=0; i<listRooms.Count; i++)
            {
                DbDataRecord room = listRooms[i] as DbDataRecord;
                if((int)room["IdCategory"] != (int)(lsbxCategories.SelectedItem as DbDataRecord)["ID"])
                {
                    listRooms.Remove(room);
                    i--;
                }
            }


            dgRooms.ItemsSource = listRooms;
        }

        private void SearchByOther()
        {
            listRooms = DataLayer.GetAllRooms();

            decimal minCost, maxCost;

            if(decimal.TryParse(txbxMinCost.Text, out minCost))
            {
                for(int i=0; i<listRooms.Count; i++)
                {
                    DbDataRecord room = listRooms[i] as DbDataRecord;
                    if(room.GetDecimal(6)<minCost)
                    {
                        listRooms.Remove(room);
                        i--;
                    }
                }
            }

            if (decimal.TryParse(txbxMaxCost.Text, out maxCost))
            {
                for (int i = 0; i < listRooms.Count; i++)
                {
                    DbDataRecord room = listRooms[i] as DbDataRecord;
                    if (room.GetDecimal(6) > maxCost)
                    {
                        listRooms.Remove(room);
                        i--;
                    }
                }
            }

            if(chbxNumberOfRooms.SelectedItem!=null)
            {
                for (int i = 0; i < listRooms.Count; i++)
                {
                    DbDataRecord room = listRooms[i] as DbDataRecord;
                    if (room.GetInt32(5) != (chbxNumberOfRooms.SelectedItem as DbDataRecord).GetInt32(3))
                    {
                        listRooms.Remove(room);
                        i--;
                    }
                }
            }

            if (chbxNumberOfSeats.SelectedItem != null)
            {
                for (int i = 0; i < listRooms.Count; i++)
                {
                    DbDataRecord room = listRooms[i] as DbDataRecord;
                    if (room.GetInt32(4) != (chbxNumberOfSeats.SelectedItem as DbDataRecord).GetInt32(2))
                    {
                        listRooms.Remove(room);
                        i--;
                    }
                }
            }

            lsbxCategories.SelectedItem = -1;
            dgRooms.ItemsSource = listRooms;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lsbxCategories.SelectedIndex = -1;
            txbxMinCost.Text = "";
            txbxMaxCost.Text = "";
            chbxNumberOfRooms.SelectedItem = null;
            chbxNumberOfSeats.SelectedItem=null;
            LoadDgRooms();
        }

        private void lsbxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchRoomsByCategory();
        }

        private void ChbxNumberOfSeats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchByOther();
        }

        private void ChbxNumberOfRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchByOther();
        }

        private void TxbxMaxCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchByOther();
        }

        private void TxbxMinCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchByOther();
        }

        private void dgRooms_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void dgRooms_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void dgRooms_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}

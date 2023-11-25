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

namespace FormularzUfoludka
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<FormData> dataList;
        public LoginWindow(List<FormData> dataList)
        {
            InitializeComponent();
            this.dataList = dataList;
        }


        private void LoginHandler(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordPasswordBox.Password;

            if (login.ToLower() == "admin" && password == "123")
            {
                this.Hide();
                DataTable dataTable = new DataTable(dataList);
                dataTable.Show();
            }
            else
            {
                MessageBox.Show("Podałeś zły login lub hasło.", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}

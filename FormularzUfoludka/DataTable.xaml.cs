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
    /// Logika interakcji dla klasy DataTable.xaml
    /// </summary>
    public partial class DataTable : Window
    {
        public DataTable(List<FormData> dataList)
        {
            InitializeComponent();

            dataListView.ItemsSource = dataList.Select(data =>
            new
            {
                Name = data.Name,
                Gender = data.Gender,
                BirthDate = data.BirthDate.ToShortDateString(),
                Age = data.Age,
                Planet = data.Planet,
                Species = data.Species,
                FavoriteFoods = string.Join(", ", data.FavoriteFoods)
            }).ToList();
        }

    }
}

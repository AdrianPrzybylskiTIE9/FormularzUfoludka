using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
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

namespace FormularzUfoludka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetAgeText(double age)
        {
            if (age == 1)
            {
                return "rok";
            }
            else if (age < 5)
            {
                return "lata";
            }
            else
            {
                return "lat";
            }
        }


        private void ageSliderHanlder(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = (int)ageSlider.Value;
            string ageText = GetAgeText(val);
            //ageDisplay.Text = $"{val} {ageText}";
        }

        private void sumbitForm(object sender, RoutedEventArgs e)
        {
            string name = nameInput.Text;
            string gender = maleRadioButton.IsChecked == true ? "Mężczyzna" : "Kobieta";
            DateTime birthDate = birthDatePicker.SelectedDate ?? DateTime.MinValue;
            int age = (int)ageSlider.Value;

            string planet = ((ComboBoxItem)planetComboBox.SelectedItem).Content.ToString();
            string spiece = ((ComboBoxItem)spieceComboBox.SelectedItem).Content.ToString();

            List<string> favoriteFoods = new List<string>();
            foreach (CheckBox item in ((StackPanel)((Expander)favoriteFoodsExpander.Content).Content).Children)
            {
                if (item.IsChecked == true)
                {
                    favoriteFoods.Add(item.Content.ToString());
                }
            }

            List<FormData> dataList = new List<FormData>();

            dataList.Add(new FormData
            {
                Name = name,
                Gender = gender,
                BirthDate = birthDate,
                Age = age,
                Planet = planet,
                Species = spiece,
                FavoriteFoods = favoriteFoods
            });

            DataTable dataTable = new DataTable();
            dataTable.dataListView.ItemsSource = dataList;
            dataTable.Show();

        }
    }

    public class FormData
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Planet { get; set; }
        public string Species { get; set; }
        public List<string> FavoriteFoods { get; set; }
    }
}

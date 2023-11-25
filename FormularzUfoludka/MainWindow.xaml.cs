using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
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
        const string filePath = "data.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sumbitForm(object sender, RoutedEventArgs e)
        {
            string name = nameInput.Text;
            string gender = maleRadioButton.IsChecked == true ? "Mężczyzna" : "Kobieta";
            DateTime birthDate = birthDatePicker.SelectedDate ?? DateTime.MinValue;
            int age = (int)ageSlider.Value;
            string planet = ((ComboBoxItem)planetComboBox.SelectedItem)?.Content?.ToString();
            string spiece = ((ComboBoxItem)spieceComboBox.SelectedItem)?.Content?.ToString();

            List<string> favoriteFoods = new List<string>();
            foreach(CheckBox item in foodsStackPanel.Children)
            {
                if (item.IsChecked == true)
                {
                    favoriteFoods.Add(item.Content.ToString());
                }
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender) || birthDate == DateTime.MinValue ||
        age == 0 || string.IsNullOrEmpty(planet) || string.IsNullOrEmpty(spiece) || favoriteFoods.Count == 0)
            {
                MessageBox.Show("Proszę wypełnić wszystkie wymagane pola.", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<FormData> dataList = LoadJsonData();

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

            SaveJson(dataList);

            MessageBox.Show("Pomyśle przyjęto twoje zgłoszenie", "Udało się!", MessageBoxButton.OK, MessageBoxImage.Information);

            ResetForm();
        }

        private void ResetForm()
        {
            nameInput.Text = string.Empty;
            maleRadioButton.IsChecked = false;
            femaleRadioButton.IsChecked = false;
            birthDatePicker.SelectedDate = DateTime.Now;
            ageSlider.Value = 0;
            planetComboBox.SelectedIndex = -1;
            spieceComboBox.SelectedIndex = -1;

            foreach (CheckBox item in foodsStackPanel.Children)
            {
                item.IsChecked = false;
            }
        }

        private List<FormData> LoadJsonData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if(!string.IsNullOrEmpty(json)) {
                    return JsonSerializer.Deserialize<List<FormData>>(json);
                }
            }
            return new List<FormData>();
        }

        private void SaveJson(List<FormData> dataList)
        {
            string json = JsonSerializer.Serialize(dataList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private void adminLogin(object sender, RoutedEventArgs e)
        {
            List<FormData> dataList = LoadJsonData();

            LoginWindow loginWindow = new LoginWindow(dataList);
            loginWindow.Show();
        }

        private void SetSliderAge(object sender, SelectionChangedEventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            DateTime birthDate = birthDatePicker.SelectedDate ?? currentDate;

            int age = currentDate.Year - birthDate.Year;
            if (currentDate < birthDate.AddYears(age))
            {
                age--;
            }

            ageSlider.Value = age;
        }

        private void SetDatePickerDate(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int age = (int)ageSlider.Value;
            DateTime currentDate = DateTime.Now;

            DateTime birthDate = currentDate.AddYears(-age);
            birthDatePicker.SelectedDate = birthDate;
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

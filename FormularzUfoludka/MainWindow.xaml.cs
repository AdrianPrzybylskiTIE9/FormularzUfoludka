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

namespace FormularzUfoludka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // https://designmodo.com/wp-content/uploads/2018/12/login-form.jpg
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string svgFilePath = "/assets/bg.svg";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(svgFilePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            svgImage.Source = bitmap;
        }
    }
}

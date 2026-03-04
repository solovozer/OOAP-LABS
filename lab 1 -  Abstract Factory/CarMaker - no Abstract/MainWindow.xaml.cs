using CarMaker.Factories;
using CarMaker.Service;
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

namespace CarMaker
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

        private string _lastReportPath;

        private void MakeCar(object sender, RoutedEventArgs e)
        {
            string factory = BrandSelector.Text switch
            {
                "Honda" => "Honda",
                "Ferrari" => "Ferrari",
                _ => "Lada"
            };

            var assembler = new CarManufacturer(factory);
            Car car = assembler.AssembleCar();

            StatusText.Text = $"Status: {car.Model} Assembled!";
            ReportContainer.Visibility = Visibility.Visible;
            ReportingService.ExportCarReport(car);
        }

        private void OpenReport(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(_lastReportPath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(_lastReportPath)
                {
                    UseShellExecute = true
                });
            }
        }
    }
}
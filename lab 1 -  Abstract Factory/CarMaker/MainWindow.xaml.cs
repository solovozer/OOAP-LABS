using CarMaker.Factories;
using CarMaker.Service;
using System.Collections.ObjectModel;
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

    public partial class MainWindow : Window
    {
        // Define a wrapper for the history table
        public class CarRecord
        {
            public Car Car { get; set; }
            public string ReportPath { get; set; }
            public DateTime CreationTime { get; set; }
        }

        private ObservableCollection<CarRecord> _history = new ObservableCollection<CarRecord>();

        public MainWindow()
        {
            InitializeComponent();
            HistoryGrid.ItemsSource = _history;
        }

        private void MakeCar(object sender, RoutedEventArgs e)
        {
            ICarFactory factory = BrandSelector.Text switch
            {
                "Honda" => new HondaFactory(),
                "Ferrari" => new FerrariFactory(),
                _ => new LadaFactory()
            };

            var assembler = new CarManufacturer(factory);
            Car car = assembler.AssembleCar();

            // Assuming ExportCarReport returns the path string. 
            // If it doesn't, you'll need to update that service to return it.
            string reportPath = ReportingService.ExportCarReport(car);

            // 1. Update the Right Tab (Photo & Name)
            ModelDisplayName.Text = car.Model;
            try
            {
                // Load photo based on model name (e.g., "Honda.jpg" in your project folder)
                CarPhoto.Source = new BitmapImage(new Uri($"pack://siteoforigin:,,,/Images/{car.Model}.jpg"));
            }
            catch { /* Fallback if image missing */ }

            // 2. Update Table (Add to top, keep max 5)
            _history.Insert(0, new CarRecord
            {
                Car = car,
                ReportPath = reportPath,
                CreationTime = DateTime.Now
            });

            if (_history.Count > 5) _history.RemoveAt(5);
        }

        private void OpenReport(object sender, RoutedEventArgs e)
        {
            // Get the specific record associated with the clicked link
            var hyperlink = (Hyperlink)sender;
            var record = (CarRecord)hyperlink.DataContext;

            if (record != null && System.IO.File.Exists(record.ReportPath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(record.ReportPath)
                {
                    UseShellExecute = true
                });
            }
        }
    }
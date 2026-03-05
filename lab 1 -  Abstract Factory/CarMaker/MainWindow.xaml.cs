using CarMaker.Factories;
using CarMaker.Service;
using HelixToolkit.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarMaker
{


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string _lastReportPath;

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

            StatusText.Text = $"Status: {car.Model} Assembled!";
            ReportContainer.Visibility = Visibility.Visible;
            ReportingService.ExportCarReport(car);
        }

        public void DisplayCar(ICarFactory factory)   //Show car model
        {
            var engine = factory.CreateEngine();
            ModelNameLabel.Text = factory.NameModel();
            string meshPath = $"Models/{factory.NameModel()}.obj";
            Update3DModel(meshPath);
        }

        private void StartSpinning()    //Spin car model
        {
            var rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            CarModelVisual.Transform = new RotateTransform3D(rotation);

            CompositionTarget.Rendering += (s, e) => {
                rotation.Angle += 1.0; 
            };
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
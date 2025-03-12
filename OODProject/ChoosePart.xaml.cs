using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OODProject
{
    /// <summary>
    /// Interaction logic for chooseCPU.xaml
    /// </summary>
    
    public partial class ChoosePart : Window
    {
        public string SelectedCpuName { get; private set; }
        public decimal SelectedCpuPrice { get; private set; }

        private string part;

        PartData db = new PartData();

        public ChoosePart()
        {
            InitializeComponent();
        }

        public ChoosePart(string button):this()
        {
            part = button;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if cpu button clicked - get cpu info from db

            if (part == "CPU")
            {
                var cpuStore = db.CPUs.ToList();

                //var cpuName = cpuStore.Select(c => c.Name).ToList();
                lbxPartsList.ItemsSource= cpuStore;
                lbxPartsList.DisplayMemberPath = "Name";

                //lbxPartsList.ItemsSource = cpuName;           
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lbxPartsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxPartsList.SelectedItem is CPU selectedCPU)
            {
                SelectedCpuName = selectedCPU.Name;
                SelectedCpuPrice = selectedCPU.Price;

                var details = db.CPUs.FirstOrDefault(c => c.CpuID == selectedCPU.CpuID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text = 
                    $"Platform: {details.Platform}\n" +
                    $"Cores: {details.Cores}, Threads: {details.Threads}\n" +
                    $"Base Clock: {details.BaseClock}GHz, Boost Clock: {details.BoostClock}GHz\n" +
                    $"Architecture: {details.Architecture}\n" +
                    $"TDP: {details.TDP} watts\n" +
                    $"Includes Cooler? {details.IncludesCooler}";

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}

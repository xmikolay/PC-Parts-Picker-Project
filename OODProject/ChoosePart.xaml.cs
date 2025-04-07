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
        #region Selected Part Variables
        public string SelectedCpuName { get; private set; }
        public decimal SelectedCpuPrice { get; private set; }

        public string SelectedMotherboardName { get; private set; }
        public decimal SelectedMotherboardPrice { get; private set; }

        public string SelectedRAMName { get; private set; }
        public decimal SelectedRAMPrice { get; private set; }

        public string SelectedGPUName { get; private set; }
        public decimal SelectedGPUPrice { get; private set; }

        public string SelectedPSUName { get; private set; }
        public decimal SelectedPSUPrice { get; private set; }

        public string SelectedCaseName { get; private set; }
        public decimal SelectedCasePrice { get; private set; }

        public string SelectedStorage1Name { get; private set; }
        public decimal SelectedStorage1Price { get; private set; }

        public string SelectedStorage2Name { get; private set; }
        public decimal SelectedStorage2Price { get; private set; }

        public string SelectedCPUCoolerName { get; private set; }
        public decimal SelectedCPUCoolerPrice { get; private set; }
        #endregion

        private CurrentBuild currentBuild;

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

        public ChoosePart(string button, CurrentBuild build) : this(button)
        {
            currentBuild = build;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if cpu button clicked - get cpu info from db

            if (part == "CPU")
            {
                var cpuQuery = db.CPUs.AsQueryable();

                if (!string.IsNullOrEmpty(currentBuild.MBPlatform))
                {
                    cpuQuery = cpuQuery
                        .Where(c => c.Platform ==  currentBuild.MBPlatform);


                }

                lbxPartsList.ItemsSource= cpuQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";        
            }

            if (part == "CPU Cooler")
            {
                var coolerStore = db.CPUCoolers.ToList();
                lbxPartsList.ItemsSource = coolerStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "Motherboard")
            {
                var mbStore = db.Motherboards.ToList();

                lbxPartsList.ItemsSource = mbStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "RAM")
            {
                var ramStore = db.RAMs.ToList();
                lbxPartsList.ItemsSource = ramStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "GPU")
            {
                var gpuStore = db.GPUs.ToList();
                lbxPartsList.ItemsSource = gpuStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "PSU")
            {
                var psuStore = db.PSUs.ToList();
                lbxPartsList.ItemsSource = psuStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "Case")
            {
                var caseStore = db.Cases.ToList();
                lbxPartsList.ItemsSource = caseStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "Storage 1" || part == "Storage 2")
            {
                var storageStore = db.Storages.ToList();
                lbxPartsList.ItemsSource = storageStore;
                lbxPartsList.DisplayMemberPath = "Name";
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
            #region CPU Parts list
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
            #endregion

            #region CPU Cooler Parts List
            if (lbxPartsList.SelectedItem is CPUCooler selectedCooler)
            {
                SelectedCPUCoolerName = selectedCooler.Name;
                SelectedCPUCoolerPrice = selectedCooler.Price;

                var details = db.CPUCoolers.FirstOrDefault(c => c.CPUCoolerID == selectedCooler.CPUCoolerID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Size: {details.Size}\n" +
                    $"Max TDP: {details.MaxTDP}W\n";

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion

            #region Motherboard Parts List
            if (lbxPartsList.SelectedItem is Motherboard selectedMB)
            {
                SelectedMotherboardName = selectedMB.Name;
                SelectedMotherboardPrice = selectedMB.Price;

                var details = db.Motherboards.FirstOrDefault(c => c.MotherboardID == selectedMB.MotherboardID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Platform: {details.Platform}\n" +
                    $"Chipset: {details.Chipset}\n" +
                    $"Max Memory Capacity: {details.MaxMemoryCapacity}GB, Memory Slots: {details.MemorySlots} Dimms\n" +
                    $"Memory Type: {details.MemoryType}\n" +
                    $"Form Factor: {details.FormFactor}\n";                   

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion

            #region RAM Parts List
            if (lbxPartsList.SelectedItem is RAM selectedRAM)
            {
                SelectedRAMName = selectedRAM.Name;
                SelectedRAMPrice = selectedRAM.Price;

                var details = db.RAMs.FirstOrDefault(c => c.RamID == selectedRAM.RamID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Type: {details.RAMType}\n" +
                    $"Modules: {details.Modules}\n" +
                    $"Capacity: {details.Capacity}GB, Speed: {details.Speed}MHz\n" +
                    $"CAS Latency: {details.CASLatency}\n";

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion

            #region GPU Parts List
            if (lbxPartsList.SelectedItem is GPU selectedGPU)
            {
                SelectedGPUName = selectedGPU.Name;
                SelectedGPUPrice = selectedGPU.Price;

                var details = db.GPUs.FirstOrDefault(c => c.GpuID == selectedGPU.GpuID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Memory Type: {details.MemoryType}, Memory Size: {details.MemorySize}GB\n" +
                    $"TDP: {details.TDP}W\n" +
                    $"Interface: {details.Interface}\n" +
                    $"External Power: {details.ExternalPower}\n" +
                    $"Reccommended PSU Power: {details.PSURequirement}W\n" +
                    $"Length: {details.GPULength}mm\n";
                    
                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion

            #region PSU Parts List
            if (lbxPartsList.SelectedItem is PSU selectedPSU)
            {
                SelectedPSUName = selectedPSU.Name;
                SelectedPSUPrice = selectedPSU.Price;

                var details = db.PSUs.FirstOrDefault(c => c.PsuID == selectedPSU.PsuID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Wattage: {details.Wattage}W\n" +
                    $"Size: {details.Size}\n" +
                    $"Efficiency Rating: {details.Efficiency}\n" +
                    $"Modularity: {details.Modularity}\n";

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion

            #region Case Parts List
            if (lbxPartsList.SelectedItem is Case selectedCase)
            {
                SelectedCaseName = selectedCase.Name;
                SelectedCasePrice = selectedCase.Price;

                var details = db.Cases.FirstOrDefault(c => c.CaseID == selectedCase.CaseID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Form Factor: {details.FormFactor}\n" +
                    $"Max GPU Length: {details.MaxGPULength}mm\n" +
                    $"Max Cooler Height: {details.MaxCoolerHeight}mm\n" +
                    $"Fans Included?: {details.FansIncluded}\n";

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion

            #region Storage Parts List
            if (lbxPartsList.SelectedItem is Storage selectedStorage)
            {
                SelectedStorage1Name = selectedStorage.Name;
                SelectedStorage2Name = selectedStorage.Name;
                SelectedStorage1Price = selectedStorage.Price;
                SelectedStorage2Price = selectedStorage.Price;

                var details = db.Storages.FirstOrDefault(c => c.StorageID == selectedStorage.StorageID);

                if (details == null)
                {
                    return;
                }

                PartName.Text = details.Name;
                PartDescription.Text =
                    $"Type: {details.Type}\n" +
                    $"Capacity: {details.Capacity}GB\n" +
                    $"Interface: {details.Interface}\n";

                if (!string.IsNullOrEmpty(details.Image))
                {
                    PartImage.Source = new BitmapImage(new Uri(details.Image, UriKind.RelativeOrAbsolute));
                }
            }
            #endregion
        }
    }
}

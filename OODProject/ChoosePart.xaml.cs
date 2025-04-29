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
using System.Data.Entity.Infrastructure;

namespace OODProject
{
    /// <summary>
    /// Interaction logic for chooseCPU.xaml
    /// </summary>
    
    public partial class ChoosePart : Window
    {
        #region Selected Part Variables

        //Creating variables to hold the selected part information
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

        //Creating currentBuild variable with CurrentBuild class type
        private CurrentBuild currentBuild;

        //Creating a type string variable to hold the part type passed on from the MainWindow button click
        private string part;

        PartData db = new PartData();

        public ChoosePart()
        {
            InitializeComponent();
        }

        //Main constructor which takes in button variable
        public ChoosePart(string button):this()
        {
            //Setting part variable to data from button variable
            part = button;
        }

        //Secondary constructor that references button variable from main constructor and gets information from MainWindow, passed into new CurrentBuild object
        public ChoosePart(string button, CurrentBuild build) : this(button)
        {
            currentBuild = build;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if cpu button clicked - get cpu info from db

            //Bunch of If statements for showing compatible parts when choosing a part. Will only explain one since theyre roughly the same.
            #region Filtering Compatible Parts...

            //Checks if part is CPU,
            if (part == "CPU")
            {
                //If so, it queries the database for CPUs
                var cpuQuery = db.CPUs.AsQueryable();

                //Check if motherboard platform variable in the CurrentBuild class is not null or empty
                if (!string.IsNullOrEmpty(currentBuild.MBPlatform))
                {
                    cpuQuery = cpuQuery
                        .Where(c => c.Platform ==  currentBuild.MBPlatform);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource= cpuQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";        
            }

            if (part == "CPU Cooler")
            {
                var coolerQuery = db.CPUCoolers.AsQueryable();

                if (!string.IsNullOrEmpty(currentBuild.CPUTdp.ToString())) 
                { 
                    coolerQuery = coolerQuery
                        .Where(c => c.MaxTDP >= currentBuild.CPUTdp);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource = coolerQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "Motherboard")
            {
                var mbQuery = db.Motherboards.AsQueryable();

                if (!string.IsNullOrEmpty(currentBuild.CPUPlatform))
                {
                    mbQuery = mbQuery
                        .Where(m => m.Platform == currentBuild.CPUPlatform);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                else if (!string.IsNullOrEmpty(currentBuild.CaseFormFactor))
                {
                    mbQuery = mbQuery
                        .Where(m => m.FormFactor == currentBuild.CaseFormFactor);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                else if (!string.IsNullOrEmpty(currentBuild.RAMType))
                {
                    mbQuery = mbQuery
                        .Where(m => m.MemoryType == currentBuild.RAMType);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource = mbQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "RAM")
            {
                var ramQuery = db.RAMs.AsQueryable();

                if (!string.IsNullOrEmpty(currentBuild.MBMemoryType))
                {
                    ramQuery = ramQuery
                        .Where(r => r.RAMType == currentBuild.MBMemoryType);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource = ramQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "GPU")
            {
                var gpuQuery = db.GPUs.AsQueryable();

                if (currentBuild.CaseMaxGPULength > 0)
                {
                    gpuQuery = gpuQuery
                        .Where(g => g.GPULength <= currentBuild.CaseMaxGPULength);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                if (currentBuild.PSUPower > 0)
                {
                    gpuQuery = gpuQuery
                        .Where(g => g.PSURequirement <= currentBuild.PSUPower);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource = gpuQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "PSU")
            {
                var psuQuery = db.PSUs.AsQueryable();

                if (currentBuild.GPUPsuReq > 0)
                {
                    psuQuery = psuQuery
                        .Where(p => p.Wattage >= currentBuild.GPUPsuReq);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource = psuQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "Case")
            {
                var caseQuery = db.Cases.AsQueryable();

                if (currentBuild.GPULength > 0)
                {
                    caseQuery = caseQuery
                        .Where(c => c.MaxGPULength >= currentBuild.GPULength);

                    lblShowingComp.Visibility = Visibility.Visible;
                }

                lbxPartsList.ItemsSource = caseQuery.ToList();
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (part == "Storage 1" || part == "Storage 2")
            {
                var storageStore = db.Storages.ToList();
                lbxPartsList.ItemsSource = storageStore;
                lbxPartsList.DisplayMemberPath = "Name";
            }

            if (currentBuild != null) 
            {
                chkbxShowComp.Visibility = Visibility.Visible;
            }

            #endregion
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

        #region Checkbox for Part Filtering
        private void chkbxShowComp_Checked(object sender, RoutedEventArgs e)
        {
            if (chkbxShowComp.IsChecked == true)
            {
                Window_Loaded(sender, e);
            }
            else
            {
                lblShowingComp.Visibility = Visibility.Collapsed;

                switch (part)
                {
                    case "CPU":
                        lbxPartsList.ItemsSource = db.CPUs.ToList();
                        break;
                    case "Motherboard":
                        lbxPartsList.ItemsSource = db.Motherboards.ToList();
                        break;
                    case "RAM":
                        lbxPartsList.ItemsSource = db.RAMs.ToList();
                        break;
                    case "GPU":
                        lbxPartsList.ItemsSource = db.GPUs.ToList();
                        break;
                    case "PSU":
                        lbxPartsList.ItemsSource = db.PSUs.ToList();
                        break;
                    case "CPU Cooler":
                        lbxPartsList.ItemsSource = db.CPUCoolers.ToList();
                        break;
                    case "Case":
                        lbxPartsList.ItemsSource = db.Cases.ToList();
                        break;
                    case "Storage 1":
                    case "Storage 2":
                        lbxPartsList.ItemsSource = db.Storages.ToList();
                        break;
                }
                lbxPartsList.DisplayMemberPath = "Name";
            }
        }
        #endregion
    }
}
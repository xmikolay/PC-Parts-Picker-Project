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

namespace OODProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //Goals:

    //Pass Part data from database, from MainWindow to ChoosePart. X
    //Have part data show in ChoosePart, show name and price of each part on right side, when clicked on more information shows up on left side. X
    //Allow user to sort by compatible parts in respect to rest of their system (e.g when user is choosing RAM, only show RAM that is compatible with chosen motherboard)
    //Pass chosen data from ChoosePart to corresponding Textblock in MainWindow. X
    //Have the compatibility checker option work in MainWindow (e.g AM5 CPU can only work with AM5 Motherboard)
    //Come up with some sort of extra function (current idea, make a main menu where you choose whether you want to create a build or view saved builds.)

    public partial class MainWindow : Window
    {
        PartData db = new PartData();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tblkCPUPrice.Text = $"{0:c}";
            tblkCoolerPrice.Text = $"{0:c}";
            tblkMBPrice.Text = $"{0:c}";
            tblkRAMPrice.Text = $"{0:c}";
            tblkGPUPrice.Text = $"{0:c}";
            tblkPSUPrice.Text = $"{0:c}";
            tblkCasePrice.Text = $"{0:c}";
            tblkStorage1Price.Text = $"{0:c}";
            tblkStorage2Price.Text = $"{0:c}";
            tblkTotalPrice.Text = $"Total: {0:c}";
        }

        #region Getting Total Price
        private void GetTotal()
        {
            decimal cpuPrice = GetPrice(tblkCPUPrice.Text.Substring(1));
            decimal cpuCoolerPrice = GetPrice(tblkCoolerPrice.Text.Substring(1));
            decimal mbPrice = GetPrice(tblkMBPrice.Text.Substring(1));
            decimal ramPrice = GetPrice(tblkRAMPrice.Text.Substring(1));
            decimal gpuPrice = GetPrice(tblkGPUPrice.Text.Substring(1));
            decimal psuPrice = GetPrice(tblkPSUPrice.Text.Substring(1));
            decimal casePrice = GetPrice(tblkCasePrice.Text.Substring(1));
            decimal storage1Price = GetPrice(tblkStorage1Price.Text.Substring(1));
            decimal storage2Price = GetPrice(tblkStorage2Price.Text.Substring(1));

            decimal total = cpuPrice + cpuCoolerPrice + mbPrice + ramPrice + gpuPrice + psuPrice + casePrice + storage1Price + storage2Price;

            tblkTotalPrice.Text = $"Total: {total:c}";
           //decimal test = GetPrice(tblkCPUPrice.Text);
        }

        private decimal GetPrice(string textBlock)
        {
            decimal price = 0;
            if (decimal.TryParse(textBlock, out price))
            {
                return price;
            }
            else 
            { 
                return 0; 
            }
        }
        #endregion

        #region Button Clicks
        private void btnCPU_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("CPU");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedCpuName;
                decimal price = choosePartWindow.SelectedCpuPrice;

                tblkCPU.Text = name;
                tblkCPUPrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnMotherboard_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("Motherboard");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedMotherboardName;
                decimal price = choosePartWindow.SelectedMotherboardPrice;

                tblkMB.Text = name;
                tblkMBPrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnRAM_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("RAM");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedRAMName;
                decimal price = choosePartWindow.SelectedRAMPrice;

                tblkRAM.Text = name;
                tblkRAMPrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnGPU_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("GPU");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedGPUName;
                decimal price = choosePartWindow.SelectedGPUPrice;

                tblkGPU.Text = name;
                tblkGPUPrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnPSU_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("PSU");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedPSUName;
                decimal price = choosePartWindow.SelectedPSUPrice;

                tblkPSU.Text = name;
                tblkPSUPrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnCase_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("Case");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedCaseName;
                decimal price = choosePartWindow.SelectedCasePrice;

                tblkCase.Text = name;
                tblkCasePrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnCooler_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("CPU Cooler");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedCPUCoolerName;
                decimal price = choosePartWindow.SelectedCPUCoolerPrice;

                tblkCooler.Text = name;
                tblkCoolerPrice.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnStorage1_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("Storage 1");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedStorage1Name;
                decimal price = choosePartWindow.SelectedStorage1Price;

                tblkStorage1.Text = name;
                tblkStorage1Price.Text = $"{price:c}";
                GetTotal();
            }
        }

        private void btnStorage2_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart("Storage 2");
            choosePartWindow.ShowDialog();

            if (choosePartWindow.DialogResult == true)
            {
                string name = choosePartWindow.SelectedStorage2Name;
                decimal price = choosePartWindow.SelectedStorage2Price;

                tblkStorage2.Text = name;
                tblkStorage2Price.Text = $"{price:c}";
                GetTotal();
            }
        }
        #endregion

        private void btnCompatibility_Click(object sender, RoutedEventArgs e)
        {
            List<string> Errors = new List<string>();

            CPU selectedCPU = null;
            Motherboard selectedMB = null;
            RAM selectedRAM = null;
            GPU selectedGPU = null;
            Case selectedCase = null;
            PSU selectedPSU = null;
            CPUCooler selectedCooler = null;

            using (var db = new PartData())
            {
                #region Setting Selected Parts To Text In Window
                if (!string.IsNullOrEmpty(tblkCPU.Text))
                {
                    selectedCPU = db.CPUs.FirstOrDefault(c => c.Name == tblkCPU.Text);
                }
                else
                {
                    Errors.Add("CPU not selected.");
                }

                if (!string.IsNullOrEmpty(tblkMB.Text))
                {
                    selectedMB = db.Motherboards.FirstOrDefault(m => m.Name == tblkMB.Text);
                }
                else
                {
                    Errors.Add("Motherboard not selected.");
                }

                if (!string.IsNullOrEmpty(tblkRAM.Text))
                {
                    selectedRAM = db.RAMs.FirstOrDefault(r => r.Name == tblkRAM.Text);
                }
                else
                {
                    Errors.Add("Ram not selected.");
                }

                if (!string.IsNullOrEmpty(tblkGPU.Text))
                {
                    selectedGPU = db.GPUs.FirstOrDefault(g => g.Name == tblkGPU.Text);
                }
                else
                {
                    Errors.Add("GPU not selected.");
                }

                if (!string.IsNullOrEmpty(tblkCase.Text))
                {
                    selectedCase = db.Cases.FirstOrDefault(cs => cs.Name == tblkCase.Text);
                }
                else
                {
                    Errors.Add("Case not selected.");
                }

                if (!string.IsNullOrEmpty(tblkPSU.Text))
                {
                    selectedPSU = db.PSUs.FirstOrDefault(p => p.Name == tblkPSU.Text);
                }
                else
                {
                    Errors.Add("PSU not selected.");
                }

                if (!string.IsNullOrEmpty(tblkCooler.Text))
                {
                    selectedCooler = db.CPUCoolers.FirstOrDefault(cc => cc.Name == tblkCooler.Text);
                }
                //else
                //{
                //    Errors.Add("CPU Cooler not selected.");
                //}
                #endregion

                #region Finding Errors for Compatibility
                if (selectedCPU != null && selectedMB != null)
                {
                    if (selectedCPU.Platform != selectedMB.Platform)
                    {
                        Errors.Add($"CPU ({selectedCPU.Name}) and Motherboard ({selectedMB.Name}) socket types do not match: {selectedCPU.Platform} and {selectedMB.Platform}");
                    }
                }

                //if (selectedCPU != null && selectedCooler != null)
                //{
                //    if (selectedCPU.TDP > selectedCooler.MaxTDP)
                //    {
                //        Errors.Add($"CPU ({selectedCPU.Name}) TDP exceeds CPU Cooler ({selectedCooler.Name}) maximum TDP: {selectedCPU.TDP}W and {selectedCooler.MaxTDP}W");
                //    }
                //    if (selectedCPU.IncludesCooler != true && selectedCooler == null)
                //    {
                //        Errors.Add($"CPU {selectedCPU.Name} does not include a cooler, please select one.");
                //    }
                //}

                if (selectedCPU != null)
                {
                    if (selectedCooler != null)
                    {
                        if (selectedCPU.TDP > selectedCooler.MaxTDP)
                        {
                            Errors.Add($"CPU ({selectedCPU.Name}) TDP exceeds CPU Cooler ({selectedCooler.Name}) maximum TDP: {selectedCPU.TDP}W and {selectedCooler.MaxTDP}W");
                        }
                    }
                    else if (selectedCPU.IncludesCooler != true)
                    {
                        Errors.Add($"CPU {selectedCPU.Name} does not include a cooler, please select one.");
                    }
                }

                if (selectedGPU != null && selectedCase != null)
                {
                    if (selectedCase.MaxGPULength < selectedGPU.GPULength)
                    {
                        Errors.Add($"GPU ({selectedGPU.Name}) length exceeds Case ({selectedCase.Name}) maximum GPU length: {selectedGPU.GPULength}mm and {selectedCase.MaxGPULength}mm");
                    }
                }

                if (selectedMB != null && selectedCase != null)
                {
                    if (selectedCase.FormFactor != selectedMB.FormFactor)
                    {
                        Errors.Add($"Motherboard ({selectedMB.Name}) form factor does not match Case ({selectedCase.Name}) form factor: {selectedMB.FormFactor} and {selectedCase.FormFactor}");
                    }
                }

                if (selectedGPU != null && selectedPSU != null)
                {
                    if (selectedGPU.PSURequirement > selectedPSU.Wattage)
                    {
                        Errors.Add($"GPU ({selectedGPU.Name}) minimum PSU wattage exceeds PSU ({selectedPSU.Name}) wattage: {selectedGPU.PSURequirement}W and {selectedPSU.Wattage}W");
                    }
                }

                if (selectedRAM != null && selectedMB != null)
                {
                    if (selectedMB.MaxMemoryCapacity < selectedRAM.Capacity)
                    {
                        Errors.Add($"Motherboard ({selectedMB.Name}) maximum RAM capacity exceeds RAM ({selectedRAM.Name}) capacity: {selectedMB.MaxMemoryCapacity} and {selectedRAM.Capacity}");
                    }

                    if (selectedMB.MemoryType != selectedRAM.RAMType)
                    {
                        Errors.Add($"Motherboard ({selectedMB.Name}) memory type does not match RAM ({selectedRAM.Name}) memory type: {selectedMB.MemoryType} and {selectedRAM.RAMType}");
                    }
                }
                #endregion

                if (Errors.Count > 0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, Errors), "Compatibility Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("All parts are compatible!", "Compatibility Check", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }    
        }

        #region Store Current PC Build in CurrentBuild class
        private CurrentBuild GetCurrentBuild()
        {
            CurrentBuild currentBuild = new CurrentBuild();

            using (var db = new PartData())
            {
                if(!string.IsNullOrEmpty(tblkCPU.Text))
                {
                    var cpu = db.CPUs.FirstOrDefault(c => c.Name == tblkCPU.Text);
                    if(cpu != null)
                    {
                        currentBuild.CPUPlatform = cpu.Platform;
                        currentBuild.CPUTdp = cpu.TDP;
                    }
                }

                if (!string.IsNullOrEmpty(tblkCooler.Text))
                {
                    var cooler = db.CPUCoolers.FirstOrDefault(c => c.Name == tblkCooler.Text);
                    if (cooler != null)
                    {
                        currentBuild.CoolerMaxTDP = cooler.MaxTDP;
                    }
                }

                if (!string.IsNullOrEmpty(tblkMB.Text))
                {
                    var mb = db.Motherboards.FirstOrDefault(m => m.Name == tblkMB.Text);
                    if (mb != null)
                    {
                        currentBuild.MBPlatform = mb.Platform;
                        currentBuild.MBFormFactor = mb.FormFactor;
                        currentBuild.MBMemoryType = mb.MemoryType;
                    }
                }

                if (!string.IsNullOrEmpty(tblkGPU.Text))
                {
                    var gpu = db.GPUs.FirstOrDefault(g => g.Name == tblkGPU.Text);
                    if (gpu != null)
                    {
                        currentBuild.GPUPsuReq = gpu.PSURequirement;
                        currentBuild.GPULength = gpu.GPULength;
                    }
                }

                if (!string.IsNullOrEmpty(tblkCase.Text))
                {
                    var pcCase = db.Cases.FirstOrDefault(c => c.Name == tblkCase.Text);
                    if (pcCase != null)
                    {
                        currentBuild.CaseFormFactor = pcCase.FormFactor;
                        currentBuild.CaseMaxGPULength = pcCase.MaxGPULength;
                    }
                }

                if (!string.IsNullOrEmpty(tblkPSU.Text))
                {
                    var psu = db.PSUs.FirstOrDefault(p => p.Name == tblkPSU.Text);
                    if (psu != null)
                    {
                        currentBuild.PSUPower = psu.Wattage;
                    }
                }

                if (!string.IsNullOrEmpty(tblkRAM.Text))
                {
                    var ram = db.RAMs.FirstOrDefault(r => r.Name == tblkRAM.Text);
                    if (ram != null)
                    {
                        currentBuild.RAMCapacity = ram.Capacity;
                        currentBuild.RAMType = ram.RAMType;
                    }
                }
            }

            return currentBuild;
        }
        #endregion
    }
}

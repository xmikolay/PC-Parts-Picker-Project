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
    //Allow user to sort by compatible parts in respect to rest of their system (e.g when user is choosing RAM, only show RAM that is compatible with chosen motherboard) X
    //Pass chosen data from ChoosePart to corresponding Textblock in MainWindow. X
    //Have the compatibility checker option work in MainWindow (e.g AM5 CPU can only work with AM5 Motherboard) X
    //Come up with some sort of extra function (current idea, make a main menu where you choose whether you want to create a build or view saved builds.)

    public partial class MainWindow : Window
    {
        //Initialising database and current build class
        PartData db = new PartData();
        CurrentBuild currentBuild = new CurrentBuild();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Giving default values for all price text blocks
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

        //Method to get total price of the build by adding all the parts prices
        private void GetTotal()
        {
            //Assigning variables as decimal after using GetPrice method to get the price from the text block
            decimal cpuPrice = GetPrice(tblkCPUPrice.Text.Substring(1));
            decimal cpuCoolerPrice = GetPrice(tblkCoolerPrice.Text.Substring(1));
            decimal mbPrice = GetPrice(tblkMBPrice.Text.Substring(1));
            decimal ramPrice = GetPrice(tblkRAMPrice.Text.Substring(1));
            decimal gpuPrice = GetPrice(tblkGPUPrice.Text.Substring(1));
            decimal psuPrice = GetPrice(tblkPSUPrice.Text.Substring(1));
            decimal casePrice = GetPrice(tblkCasePrice.Text.Substring(1));
            decimal storage1Price = GetPrice(tblkStorage1Price.Text.Substring(1));
            decimal storage2Price = GetPrice(tblkStorage2Price.Text.Substring(1));

            //Adding all variables to get total
            decimal total = cpuPrice + cpuCoolerPrice + mbPrice + ramPrice + gpuPrice + psuPrice + casePrice + storage1Price + storage2Price;

            //Displaying total
            tblkTotalPrice.Text = $"Total: {total:c}";
           //decimal test = GetPrice(tblkCPUPrice.Text);
        }

        //GetPrice method to convert the string from the text block to decimal
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

        //A lot of the button clicks are the same, so I will just explain one of them
        private void btnCPU_Click(object sender, RoutedEventArgs e)
        {
            CurrentBuild currentBuild = GetCurrentBuild(); //Referencing GetCurrentBuild method

            //Once the button is clicked it passes 2 values to the ChoosePart window: The part name, and current build values used for filtering
            ChoosePart choosePartWindow = new ChoosePart("CPU", currentBuild); 
            choosePartWindow.ShowDialog(); //Shows window

            //If add button is clicked in choose part window, the window returns a DialogResult of true
            //No outcome if Choose part window is closed
            if (choosePartWindow.DialogResult == true)
            {
                //Setting the name and price of the selected part in choose part window to variables
                string name = choosePartWindow.SelectedCpuName;
                decimal price = choosePartWindow.SelectedCpuPrice;

                //Setting those variables to the text blocks in the main window
                tblkCPU.Text = name;
                tblkCPUPrice.Text = $"{price:c}";

                //Calling GetTotal method to update total after each successfull part selection
                GetTotal();
            }
        }

        private void btnMotherboard_Click(object sender, RoutedEventArgs e)
        {
            CurrentBuild currentBuild = GetCurrentBuild();
            ChoosePart choosePartWindow = new ChoosePart("Motherboard", currentBuild);
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
            CurrentBuild currentBuild = GetCurrentBuild();
            ChoosePart choosePartWindow = new ChoosePart("RAM", currentBuild);
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
            CurrentBuild currentBuild = GetCurrentBuild();
            ChoosePart choosePartWindow = new ChoosePart("GPU", currentBuild);
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
            CurrentBuild currentBuild = GetCurrentBuild();
            ChoosePart choosePartWindow = new ChoosePart("PSU", currentBuild);
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
            CurrentBuild currentBuild = GetCurrentBuild();
            ChoosePart choosePartWindow = new ChoosePart("Case", currentBuild);
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
            CurrentBuild currentBuild = GetCurrentBuild();
            ChoosePart choosePartWindow = new ChoosePart("CPU Cooler", currentBuild);
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

        //Here is everything that happens when you press the Compatibility check button in the main window
        private void btnCompatibility_Click(object sender, RoutedEventArgs e)
        {
            //Initialise list that will hold any errors
            List<string> Errors = new List<string>();

            //Set some temporary part variables to null
            CPU selectedCPU = null;
            Motherboard selectedMB = null;
            RAM selectedRAM = null;
            GPU selectedGPU = null;
            Case selectedCase = null;
            PSU selectedPSU = null;
            CPUCooler selectedCooler = null;

            //Using the database to get any part data needed for compatibility check
            using (var db = new PartData())
            {
                #region Setting Selected Parts To Text In Window

                //Just like the button clicks, all these are mostly the same so I will just explain one
                //Storage is not included in any sort of compatibility check since all the parts that I have in the database are compatible with all storage options.

                //Checks if part text block is not empty
                if (!string.IsNullOrEmpty(tblkCPU.Text))
                {
                    //If its not empty, assign previously created variable to the first part in the database that matches the text in the text block
                    selectedCPU = db.CPUs.FirstOrDefault(c => c.Name == tblkCPU.Text);
                }
                else
                {
                    //Else add an error to the error list, telling the user that they have not yet selected a part
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

                //This is where all the compatibility checks are done for the button, if any of them fail, an error is added to the list

                //If the CPU and Motherboard are not null (meaning they have been selected).....
                if (selectedCPU != null && selectedMB != null)
                {
                    //Then check if the CPU and Motherboard socket types dont match
                    if (selectedCPU.Platform != selectedMB.Platform)
                    {
                        //If they dont, add an error to the list
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

                //Check if CPU is selected
                if (selectedCPU != null)
                {
                    //If it is, check if Cooler is selected 
                    if (selectedCooler != null)
                    {
                        //If it is, check if the CPU TDP is greater than the Cooler max TDP
                        if (selectedCPU.TDP > selectedCooler.MaxTDP)
                        {
                            //If it is, add an error to the list
                            Errors.Add($"CPU ({selectedCPU.Name}) TDP exceeds CPU Cooler ({selectedCooler.Name}) maximum TDP: {selectedCPU.TDP}W and {selectedCooler.MaxTDP}W");
                        }
                    }
                    //Else if the cooler is not selected, check if the CPU doesnt include a cooler
                    else if (selectedCPU.IncludesCooler != true)
                    {
                        //If it doesnt, add an error to the list
                        Errors.Add($"CPU {selectedCPU.Name} does not include a cooler, please select one.");
                    }
                }

                //Checks if the selected case allows for the selected gpu length
                if (selectedGPU != null && selectedCase != null)
                {
                    if (selectedCase.MaxGPULength < selectedGPU.GPULength)
                    {
                        Errors.Add($"GPU ({selectedGPU.Name}) length exceeds Case ({selectedCase.Name}) maximum GPU length: {selectedGPU.GPULength}mm and {selectedCase.MaxGPULength}mm");
                    }
                }

                //Checks if the selected case supports the selected motherboard form factor
                if (selectedMB != null && selectedCase != null)
                {
                    if (selectedCase.FormFactor != selectedMB.FormFactor)
                    {
                        Errors.Add($"Motherboard ({selectedMB.Name}) form factor does not match Case ({selectedCase.Name}) form factor: {selectedMB.FormFactor} and {selectedCase.FormFactor}");
                    }
                }

                //Checks if the selected GPU power requirement is greater than the selected PSU wattage
                if (selectedGPU != null && selectedPSU != null)
                {
                    if (selectedGPU.PSURequirement > selectedPSU.Wattage)
                    {
                        Errors.Add($"GPU ({selectedGPU.Name}) minimum PSU wattage exceeds PSU ({selectedPSU.Name}) wattage: {selectedGPU.PSURequirement}W and {selectedPSU.Wattage}W");
                    }
                }

                //Checks if the selected Motherboard max memory capacity is less than the selected RAM capacity,
                //and if the selected motherboard memory type is the same as the selected RAM type
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

                //If there are any errors in the list, show them to the user in a message box, if not show a success message in message box
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

        //Method to store compatibility information about selected parts, and then to pass that information to CurrentBuild class
        private CurrentBuild GetCurrentBuild()
        {
            //Initialise current build class
            CurrentBuild currentBuild = new CurrentBuild();

            //Using the database to get any part data needed for compatibility check
            using (var db = new PartData())
            {
                //If cpu text block is not empty, assign the CPU platform and TDP to corresponding variables in the current build class
                if (!string.IsNullOrEmpty(tblkCPU.Text))
                {
                    var cpu = db.CPUs.FirstOrDefault(c => c.Name == tblkCPU.Text);
                    if(cpu != null)
                    {
                        currentBuild.CPUPlatform = cpu.Platform;
                        currentBuild.CPUTdp = cpu.TDP;
                    }
                }

                //If cooler text block is not empty, assign the cooler max TDP to corresponding variables current build class
                if (!string.IsNullOrEmpty(tblkCooler.Text))
                {
                    var cooler = db.CPUCoolers.FirstOrDefault(c => c.Name == tblkCooler.Text);
                    if (cooler != null)
                    {
                        currentBuild.CoolerMaxTDP = cooler.MaxTDP;
                    }
                }

                //If motherboard text block is not empty, assign the platform, form factor and memory type to corresponding variables current build class
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

                //If gpu text block is not empty, assign the gpu power requirement and gpu length to corresponding variables current build class
                if (!string.IsNullOrEmpty(tblkGPU.Text))
                {
                    var gpu = db.GPUs.FirstOrDefault(g => g.Name == tblkGPU.Text);
                    if (gpu != null)
                    {
                        currentBuild.GPUPsuReq = gpu.PSURequirement;
                        currentBuild.GPULength = gpu.GPULength;
                    }
                }

                //If cooler text block is not empty, assign the cooler max TDP to corresponding variables current build class
                if (!string.IsNullOrEmpty(tblkCase.Text))
                {
                    var pcCase = db.Cases.FirstOrDefault(c => c.Name == tblkCase.Text);
                    if (pcCase != null)
                    {
                        currentBuild.CaseFormFactor = pcCase.FormFactor;
                        currentBuild.CaseMaxGPULength = pcCase.MaxGPULength;
                    }
                }

                //If psu text block is not empty, assign the psu wattage to corresponding variables current build class
                if (!string.IsNullOrEmpty(tblkPSU.Text))
                {
                    var psu = db.PSUs.FirstOrDefault(p => p.Name == tblkPSU.Text);
                    if (psu != null)
                    {
                        currentBuild.PSUPower = psu.Wattage;
                    }
                }

                //If ram text block is not empty, assign the ram type to corresponding variables current build class
                if (!string.IsNullOrEmpty(tblkRAM.Text))
                {
                    var ram = db.RAMs.FirstOrDefault(r => r.Name == tblkRAM.Text);
                    if (ram != null)
                    {
                        currentBuild.RAMType = ram.RAMType;
                    }
                }
            }

            //Return information about the current build
            return currentBuild;
        }
        #endregion

        #region Buttons to remove Part Selections

        //These are all buttons that remove each corresponding part from selection
        //The buttons are all the same so i will just explain one

        //Button to remove CPU selection
        private void btnRemoveCPU_Click(object sender, RoutedEventArgs e)
        {
            //Set the name text block to null
            tblkCPU.Text = null;

            //Set the price text block to 0
            tblkCPUPrice.Text = $"{0:c}";

            //Update the total price after removing part
            GetTotal();
        }

        private void btnRemoveCooler_Click(object sender, RoutedEventArgs e)
        {
            tblkCooler.Text = null;
            tblkCoolerPrice.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemoveMB_Click(object sender, RoutedEventArgs e)
        {
            tblkMB.Text = null;
            tblkMBPrice.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemoveRAM_Click(object sender, RoutedEventArgs e)
        {
            tblkRAM.Text = null;
            tblkRAMPrice.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemoveGPU_Click(object sender, RoutedEventArgs e)
        {
            tblkGPU.Text = null;
            tblkGPUPrice.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemovePSU_Click(object sender, RoutedEventArgs e)
        {
            tblkPSU.Text = null;
            tblkPSUPrice.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemoveCase_Click(object sender, RoutedEventArgs e)
        {
            tblkCase.Text = null;
            tblkCasePrice.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemoveStorage1_Click(object sender, RoutedEventArgs e)
        {
            tblkStorage1.Text = null;
            tblkStorage1Price.Text = $"{0:c}";
            GetTotal();
        }

        private void btnRemoveStorage2_Click(object sender, RoutedEventArgs e)
        {
            tblkStorage2.Text = null;
            tblkStorage2Price.Text = $"{0:c}";
            GetTotal();
        }
        #endregion
    }
}

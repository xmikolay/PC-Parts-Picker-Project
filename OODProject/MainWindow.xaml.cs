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

    //Pass Part data from database, from MainWindow to ChoosePart.
    //Have part data show in ChoosePart, show name and price of each part on right side, when clicked on more information shows up on left side.
    //Allow user to sort by compatible parts in respect to rest of their system (e.g when user is choosing RAM, only show RAM that is compatible with chosen motherboard)
    //Pass chosen data from ChoosePart to corresponding Textblock in MainWindow
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
    }
}

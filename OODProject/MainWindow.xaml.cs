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
            double cpuPrice = GetPrice(tblkCPUPrice.Text);
            double cpuCoolerPrice = GetPrice(tblkCoolerPrice.Text);
            double mbPrice = GetPrice(tblkMBPrice.Text);
            double ramPrice = GetPrice(tblkRAMPrice.Text);
            double gpuPrice = GetPrice(tblkGPUPrice.Text);
            double psuPrice = GetPrice(tblkPSUPrice.Text);
            double casePrice = GetPrice(tblkCasePrice.Text);
            double storage1Price = GetPrice(tblkStorage1Price.Text);
            double storage2Price = GetPrice(tblkStorage2Price.Text);

            double total = cpuPrice + cpuCoolerPrice + mbPrice + ramPrice + gpuPrice + psuPrice + casePrice + storage1Price + storage2Price;

            tblkTotalPrice.Text = $"Total: {total:c}";
        }

        private double GetPrice(string textBlock)
        {
            double price = 0;
            if (double.TryParse(textBlock, out price))
            {
                return price;
            }
            else { return 0; }
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


    }
}

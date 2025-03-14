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
            }
        }
    }
}

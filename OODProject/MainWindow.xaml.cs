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
    public partial class MainWindow : Window
    {
        //Main Window code
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCPU_Click(object sender, RoutedEventArgs e)
        {
            ChoosePart choosePartWindow = new ChoosePart();
            choosePartWindow.ShowDialog();
        }
    }
}

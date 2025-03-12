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

                var cpuToString = cpuStore.Select(c => c.ToString()).ToList();
                lbxPartsList.ItemsSource = cpuToString;

                //var imageSource = cpuStore.Select(c => c.Image).FirstOrDefault();

                //if (!string.IsNullOrEmpty(imageSource))
                //{
                //    PartImage.Source = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
                //}              
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //OnReturn(null);
            this.Close();
        }       
    }
}

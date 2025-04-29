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
using System.Windows.Shapes;
using System.IO;

namespace OODProject
{
    /// <summary>
    /// Interaction logic for SavedBuildsWindow.xaml
    /// </summary>
    public partial class SavedBuildsWindow : Window
    {
        public SavedBuildsWindow()
        {
            InitializeComponent();
            LoadSavedBuilds();
        }

        private void LoadSavedBuilds()
        {
            if (!File.Exists("savedbuilds.csv"))
                return;

            var lines = File.ReadAllLines("savedbuilds.csv");
            if (lines.Length <= 1) return;

            int buildNumber = 1;

            foreach (var line in lines.Skip(1))
            {
                var fields = line.Split(',');

                if (fields.Length < 19) continue;

                var buildHeader = new TextBlock
                {
                    Text = $"Build {buildNumber}",
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 10, 0, 5)
                };

                var buildDetails = new StackPanel
                {
                    Margin = new Thickness(10, 0, 0, 20)
                };

                string[] partNames = {
                    "CPU", "CPU Cooler", "Motherboard", "RAM", "GPU", "PSU", "Case", "Storage 1", "Storage 2", "Total"
                };

                for (int i = 0; i < partNames.Length; i++)
                {
                    string part = i < 9 ? $"{partNames[i]}: {fields[i * 2]} - {fields[i * 2 + 1]}" :
                                          $"{partNames[i]}: {fields[18]}";

                    buildDetails.Children.Add(new TextBlock
                    {
                        Text = part,
                        FontSize = 14,
                        Margin = new Thickness(0, 2, 0, 2)
                    });
                }

                Builds.Children.Add(buildHeader);
                Builds.Children.Add(buildDetails);

                buildNumber++;
            }
        }
    }

    public class SavedBuild
    {
        public string CPU { get; set; }
        public string CPUPrice { get; set; }
        public string CPUCooler { get; set; }
        public string CPUCoolerPrice { get; set; }
        public string Motherboard { get; set; }
        public string MotherboardPrice { get; set; }
        public string RAM { get; set; }
        public string RAMPrice { get; set; }
        public string GPU { get; set; }
        public string GPUPrice { get; set; }
        public string PSU { get; set; }
        public string PSUPrice { get; set; }
        public string Case { get; set; }
        public string CasePrice { get; set; }
        public string Storage1 { get; set; }
        public string Storage1Price { get; set; }
        public string Storage2 { get; set; }
        public string Storage2Price { get; set; }
        public string TotalPrice { get; set; }
    }
}
